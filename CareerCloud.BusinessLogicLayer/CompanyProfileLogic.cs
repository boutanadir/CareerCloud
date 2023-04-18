using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyProfileLogic : BaseLogic<CompanyProfilePoco>
    {
        public CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repository) : base(repository)
        {
        }

        public override void Add(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override CompanyProfilePoco Get(Guid id)
        {
            return base.Get(id);
        }

        public override List<CompanyProfilePoco> GetAll()
        {
            return base.GetAll();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }

        public override void Update(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyProfilePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach (var poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.ContactPhone)) exceptions.Add(new ValidationException(601, "Must correspond to a valid phonenumber (e.g. 416-555-1234)"));
                else{
                    string[] phoneComponents = poco.ContactPhone.Split('-');
                    if (phoneComponents.Length != 3)
                    {
                        exceptions.Add(new ValidationException(601, "Must correspond to a valid phonenumber (e.g. 416-555-1234)"));
                    }
                    else
                    {
                        if (phoneComponents[0].Length != 3)
                        {
                            exceptions.Add(new ValidationException(601, "Must correspond to a valid phonenumber (e.g. 416-555-1234)"));
                        }
                        else if (phoneComponents[1].Length != 3)
                        {
                            exceptions.Add(new ValidationException(601, "Must correspond to a valid phonenumber (e.g. 416-555-1234)"));
                        }
                        else if (phoneComponents[2].Length != 4)
                        {
                            exceptions.Add(new ValidationException(601, "Must correspond to a valid phonenumber (e.g. 416-555-1234)"));
                        }
                    }
                }
                if (string.IsNullOrEmpty(poco.CompanyWebsite) || !Regex.IsMatch(poco.CompanyWebsite, @"$ (?<=\.(ca|com|biz))", RegexOptions.IgnoreCase))
                    exceptions.Add(new ValidationException(600, "Valid websites must end with thefollowing extensions – \".ca\",\".com\", \".biz"));
            }

            if (exceptions.Count > 0) throw new AggregateException(exceptions);
        }
    }
}
