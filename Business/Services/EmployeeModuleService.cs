//using DataAccess.EmployeeModuleRepository;
//using DataAccess.Models;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Business.Services
//{
//    public class EmployeeModuleService
//    {
//        private readonly EmployeeRepo _repo;
//        public EmployeeModuleService(EmployeeRepo repo)
//        {
//            _repo = repo;
//        }
//        public async Task<dynamic> GetnameService(string name)
//        {

//            var res = await _repo.GetnameRepo(name);
//            return res;
//        }
//        public async Task<IActionResult> GetallempdetailsService()
//        {

//            var res = await _repo.GetAllempdetailsrepo();
//            return res;
//        }
//        public async Task<IActionResult> GetEmpnameservice()
//        {

//            var res = await _repo.GetEmpnamesrepo();
//            return res;
//        }
//        public async Task<IActionResult> Searchbyidservice(int id)
//        {

//            var res = await _repo.Searchbyidrepo(id);
//            return res;
//        }
//        public async Task<IActionResult> InsertEmpService(EmployeeModel employee)
//        {

//            var res = await _repo.InsertEmpRepo(employee);
//            return res;
//        }
//        public async Task<IActionResult> ModifyEmpService(EmployeeModel employee)
//        {

//            var res = await _repo.ModifyEmpRepo(employee);
//            return res;
//        }
//        public async Task<IActionResult> RemoveEmpService(EmployeeModel employee)
//        {

//            var res = await _repo.RemoveEmpRepo(employee);
//            return res;
//        }
//    }
//}
