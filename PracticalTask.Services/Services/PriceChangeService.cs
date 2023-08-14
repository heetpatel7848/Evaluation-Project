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
        private readonly IItemRepository _itemRepository;

        public PriceChangeService(IPriceChangeRepository repository, IMapper mapper , IItemRepository itemRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _itemRepository = itemRepository;
        }

        public IEnumerable<PriceChangeDTO> GetPriceChanges()
        {
            var priceChanges = _repository.GetPriceChanges();
            return _mapper.Map<IEnumerable<PriceChangeDTO>>(priceChanges);
        }

        public IEnumerable<Item> GetItemsByItemCodes(List<int> itemCodes)
        {
            return _itemRepository.GetItemsByItemCodes(itemCodes);
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

        public void ApplyPriceChangesToItems(int srno)
        {
            var priceChange = _repository.GetPriceChangeById(srno);
            if (priceChange == null)
            {
                throw new Exception("PriceChange not found.");
            }

            // Fetch the item from the Item table based on ItemCode
            var itemToUpdate = _repository.GetItemByItemCode(priceChange.ItemCode);
            if (itemToUpdate == null)
            {
                throw new Exception("Item not found.");
            }

            // Calculate the new cost and price based on the change type, price type, and change options
            if (priceChange.Increase_Decrease == "increase")
            {
                if (priceChange.PriceType == "$")
                {
                    if (priceChange.PriceUpdate == "cost" || priceChange.PriceUpdate == "costAndPrice")
                    {
                        itemToUpdate.Cost += priceChange.NewCost;
                    }
                    if (priceChange.PriceUpdate == "price" || priceChange.PriceUpdate == "costAndPrice")
                    {
                        itemToUpdate.Price += priceChange.NewPrice;
                    }
                }
                // Handle percentage increase similarly
            }
            else if (priceChange.Increase_Decrease == "decrease")
            {
                // Handle decrease logic similarly
            }

            // Update the item in the Item table
            _itemRepository.UpdateItem(itemToUpdate);
        }

    }
}

