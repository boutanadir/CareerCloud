using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyJobDescriptionLogic : BaseLogic<CompanyJobDescriptionPoco>
    {
        public CompanyJobDescriptionLogic(IDataRepository<CompanyJobDescriptionPoco> repository) : base(repository)
        {
        }

        public override void Add(CompanyJobDescriptionPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override CompanyJobDescriptionPoco Get(Guid id)
        {
            return base.Get(id);
        }

        public override List<CompanyJobDescriptionPoco> GetAll()
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

        public override void Update(CompanyJobDescriptionPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyJobDescriptionPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach (var poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.JobName)) exceptions.Add(new ValidationException(300, "JobName cannot be empty"));
              
                if (string.IsNullOrEmpty(poco.JobDescriptions)) exceptions.Add(new ValidationException(301, "JobDescriptions cannot be empt"));
            }

            if (exceptions.Count > 0) throw new AggregateException(exceptions);
        }
    }
}
