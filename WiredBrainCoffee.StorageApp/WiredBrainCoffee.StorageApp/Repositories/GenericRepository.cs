﻿using System;
using System.Collections.Generic;
using System.Linq;
using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Responsitories
{
    public class GenericRepository<T> where T : EntityBase
    {
        private readonly List<T> _items = new();

        public T GetById(int id)
        {
            return _items.Single(item => item.Id == id);
        }

        public void Add(T item)
        {
            _items.Add(item);
        }

        public void Save()
        {
            foreach (var item in _items)
            {
                Console.WriteLine(item);
            }
        }
        public void Remove(T item)
        {
            _items.Remove(item);
        }
    }
}
