﻿using ConsoleAppTDD.Interface;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ConsoleAppTDD.Services;

public class CustomerService : ICustomerService
{
    private readonly IFileService _fileService;

    public CustomerService(IFileService fileService)
    {
        _fileService = fileService;
    }

    private readonly string _filePath = @"U:\.NET\C#(C-sharp)\Projects\customers.json";
    private List<ICustomer> _customerList = new List<ICustomer>();

    public bool AddToList(ICustomer customer)
    {
        try
        {
            customer.Id = _customerList.Count + 1;
            _customerList.Add(customer);


            var json = JsonConvert.SerializeObject(_customerList, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects,
            });

            _fileService.SaveToFile(_filePath, json);

            return true;
        }
        catch (Exception ex){ Debug.WriteLine(ex.Message); }
        return false;
    }

    public IEnumerable<ICustomer> GetAllFromList()
    {
        try
        {
            var content = _fileService.GetContentFromFile(_filePath);
            if (!string.IsNullOrEmpty(content))
            {
                _customerList = JsonConvert.DeserializeObject<List<ICustomer>>(content, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects,
                })!;
            }

            return _customerList;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null;
    }
}
