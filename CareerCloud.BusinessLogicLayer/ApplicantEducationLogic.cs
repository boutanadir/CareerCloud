﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantEducationLogic : BaseLogic<ApplicantEducationPoco>
    {
        public ApplicantEducationLogic(IDataRepository<ApplicantEducationPoco> repository) : base(repository)
        {
        }

        public override void Add(ApplicantEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override ApplicantEducationPoco Get(Guid id)
        {
            return base.Get(id);
        }

        public override List<ApplicantEducationPoco> GetAll()
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

        public override void Update(ApplicantEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(ApplicantEducationPoco[] pocos)
        {

            List<ValidationException> exceptions = new List<ValidationException>();

            foreach (var poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Major) || poco.Major.Length < 3) exceptions.Add(new ValidationException(107, "Cannot be empty or less than 3characters"));

                if (poco.StartDate > DateTime.Now.Date) exceptions.Add(new ValidationException(108, "Cannot be greater than today"));

                if (poco.CompletionDate < poco.StartDate) exceptions.Add(new ValidationException(109, "CompletionDate cannot be earlierthan StartDate"));
            }

            if (exceptions.Count > 0) throw new AggregateException(exceptions);
        }
    
    }
}
