using AutoMapper.Execution;
using AutoMapper;
using PracticalTask.Models.Interface;
using PracticalTask.Models;
using PracticalTask.Services.DTO;
using PracticalTask.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTask.Services.Services
{
    public class PriceChangeService : IPriceChangeService
    {
        private readonly IPriceChangeRepository _repository;
        private readonly IMapper _mapper;

        public PriceChangeService(IPriceChangeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<PriceChangeDTO> GetPriceChanges()
        {
            var priceChanges = _repository.GetPriceChanges();
            return _mapper.Map<IEnumerable<PriceChangeDTO>>(priceChanges);
        }

        public PriceChangeDTO GetPriceChangeById(int srno)
        {
            var priceChange = _repository.GetPriceChangeById(srno);
            return _mapper.Map<PriceChangeDTO>(priceChange);
        }

        public int CreatePriceChange(PriceChangeDTO priceChangeDto)
        {
            var newPriceChange = _mapper.Map<PriceChange>(priceChangeDto);
            return _repository.CreatePriceChange(newPriceChange);
        }

        public void UpdatePriceChange(int srno, PriceChangeDTO priceChangeDto)
        {
            var existingPriceChange = _repository.GetPriceChangeById(srno);
            if (existingPriceChange == null)
            {
                throw new Exception("PriceChange not found.");
            }

            _mapper.Map(priceChangeDto, existingPriceChange);
            _repository.UpdatePriceChange(existingPriceChange);
        }

        public void DeletePriceChange(int srno)
        {
            var existingPriceChange = _repository.GetPriceChangeById(srno);
            if (existingPriceChange == null)
            {
                throw new Exception("PriceChange not found.");
            }

            _repository.DeletePriceChange(srno);
        }
    }
}

