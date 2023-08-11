using AutoMapper;
using PracticalTask.Models.Interface;
using PracticalTask.Models;
using PracticalTask.Services.DTO;
using PracticalTask.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTask.Services.Services
{
        public class ItemService : IItemService
        {
            private readonly IItemRepository _repository;
            private readonly IMapper _mapper;

            public ItemService(IItemRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public IEnumerable<ItemDTO> GetItems()
            {
                var items = _repository.GetItems();
                return _mapper.Map<IEnumerable<ItemDTO>>(items);
            }

            public ItemDTO GetItemById(int srno)
            {
                var item = _repository.GetItemById(srno);
                return _mapper.Map<ItemDTO>(item);
            }

            public int CreateItem(ItemDTO itemDto)
            {
                var newItem = _mapper.Map<Item>(itemDto);
                return _repository.CreateItem(newItem);
            }

            public void UpdateItem(int srno, ItemDTO itemDto)
            {
                var existingItem = _repository.GetItemById(srno);
                if (existingItem == null)
                {
                    throw new Exception("Item not found.");
                }

                _mapper.Map(itemDto, existingItem);
                existingItem.Srno = srno;
                _repository.UpdateItem(existingItem);
            }

            public void DeleteItem(int srno)
            {
                var existingItem = _repository.GetItemById(srno);
                if (existingItem == null)
                {
                    throw new Exception("Item not found.");
                }

                _repository.DeleteItem(srno);
            }
        }
    }