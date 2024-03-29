﻿using CodeWebCuaTui.Models;
using CodeWebCuaTui.IServices;
using Microsoft.EntityFrameworkCore;

namespace CodeWebCuaTui.Services
{
    public class BillServices : IBillServices
    {
        CodeWebCuaTuiDbContex _context;
        public BillServices()
        {
            _context = new CodeWebCuaTuiDbContex();
        }

        public bool CreateBill(Bill p)
        {
            try
            {
                p.BillCode = Matt();
                _context.Bills.Add(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public string Matt()
        {
            if (_context.Bills.Count() == 0)
            {
                return "BILL1";
            }
            else return "BILL" + _context.Bills.Max(c => Convert.ToInt32(c.BillCode.Substring(4, c.BillCode.Length - 4)) + 1);
        }
        public bool DeleteBill(Guid id)
        {
            try
            {
                var p = _context.Bills.Find(id);
                _context.Bills.Remove(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Bill> GetAllBills()
        {
            return _context.Bills.Include("User").ToList();
        }

        public Bill GetBillById(Guid id)
        {
            return _context.Bills.FirstOrDefault(p => p.ID == id);
        }

        public List<Bill> GetBillByName(string name)
        {
            return _context.Bills.Where(p => p.BillCode.Contains(name)).ToList();
        }

        public bool UpdateBill(Bill p)
        {
            try
            {
                var a = _context.Bills.Find(p.ID);
                a.UserID = p.UserID;
                a.BillCode = p.BillCode;
                a.DateCreate = p.DateCreate;
                a.DateOfPay = p.DateOfPay;
                a.Name = p.Name;
                a.Address = p.Address;
                a.Phone = p.Phone;
                a.Describe = p.Describe;
                a.TotalAmount = p.TotalAmount;
                a.Status = p.Status;

                _context.Bills.Update(a);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
