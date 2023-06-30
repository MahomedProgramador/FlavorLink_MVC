using Domain.Models;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
	public class MeasurementService : IMeasurementService
	{

		private readonly IMeasurementRepository _measurementRepository;

        public MeasurementService(IMeasurementRepository measurementRepository)
        {
			_measurementRepository = measurementRepository;            
        }
        public void Add()
		{
			_measurementRepository.Add();
		}

		public IEnumerable<Measurement> GetAll()
		{
			return _measurementRepository.GetAll();
		}

		public Measurement GetById(int id)
		{
			return _measurementRepository.GetById(id);
		}



		public void Update()
		{
			_measurementRepository.Update();
		}
	}
}
