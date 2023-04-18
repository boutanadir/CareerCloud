using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantSkillLogic : BaseLogic<ApplicantSkillPoco>
    {
        public ApplicantSkillLogic(IDataRepository<ApplicantSkillPoco> repository) : base(repository)
        {
        }

        public override void Add(ApplicantSkillPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override ApplicantSkillPoco Get(Guid id)
        {
            return base.Get(id);
        }

        public override List<ApplicantSkillPoco> GetAll()
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

        public override void Update(ApplicantSkillPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(ApplicantSkillPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            
            foreach (var poco in pocos)
            {
                if (poco.StartMonth > 12) exceptions.Add(new ValidationException(101, "Cannot be greater than 12"));

                if (poco.EndMonth > 12) exceptions.Add(new ValidationException(102, "Cannot be greater than 12"));
                
                if (poco.StartYear < 1900) exceptions.Add(new ValidationException(103, "Cannot be less then 19"));
                
                if (poco.EndYear < poco.StartYear) exceptions.Add(new ValidationException(104, "Cannot be less then StartYear"));
            }
            
            if (exceptions.Count > 0) throw new AggregateException(exceptions);
        }
    }
}
