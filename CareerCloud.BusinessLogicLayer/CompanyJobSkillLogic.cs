﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyJobSkillLogic : BaseLogic<CompanyJobSkillPoco>
    {
        public CompanyJobSkillLogic(IDataRepository<CompanyJobSkillPoco> repository) : base(repository)
        {
        }

        public override void Add(CompanyJobSkillPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override CompanyJobSkillPoco Get(Guid id)
        {
            return base.Get(id);
        }

        public override List<CompanyJobSkillPoco> GetAll()
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

        public override void Update(CompanyJobSkillPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyJobSkillPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach (var poco in pocos)
                if (poco.Importance < 0) 
                    exceptions.Add(new ValidationException(400, "Importance cannot be less than 0"));
              
            if (exceptions.Count > 0) throw new AggregateException(exceptions);
        }
    }
}
