using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
	public interface IMeasurementRepository
	{
		public IEnumerable<Measurement> GetAll();
		public Measurement GetById(int id);
		public void Add();
		public void Update();
		
	}
}
