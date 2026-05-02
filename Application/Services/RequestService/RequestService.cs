
using Application.Reposetories;
using Application.Services.CurrentUserService;
using Application.Services.RequestService.RequestDTOs;
using Domain.Entites;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.RequestService
{
    public class RequestService : IRequestService
    {
        private readonly IGenericRepository<Request> _requestRepo;
        private readonly IGenericRepository<RequestHitory> _historyRepo;
        private readonly IGenericRepository<Category> _categoryRepo;
        private readonly ICurrentUserService _currentUser;

        public RequestService(
            IGenericRepository<Request> requestRepo,
            IGenericRepository<RequestHitory> historyRepo,
            IGenericRepository<Category> categoryRepo,
            ICurrentUserService currentUser)
        {
            _requestRepo = requestRepo;
            _historyRepo = historyRepo;
            _categoryRepo = categoryRepo;
            _currentUser = currentUser;
        }

        // 🔹 Create Request
        public async Task CreateRequest(CreateRequestDto input)
        {
            // ✅ جلب الكاتيجوري من الاسم (Seed Data)
            var category = await _categoryRepo.GetAll()
                .FirstOrDefaultAsync(x => x.Name.ToLower() == input.CategoryName.ToLower());

            if (category == null)
                throw new Exception("Category not found");

            if (_currentUser.UserId == null)
                throw new Exception("User not logged in");

            var request = new Request
            {
                Id = Guid.NewGuid(),
                Title = input.Title,
                Description = input.Description,
                CategoryId = category.Id,
                Location = input.Location,
                EmployeeId = _currentUser.UserId.Value,
                CreatedAt = DateTime.UtcNow,
                status = RequestStatus.New
            };

            await _requestRepo.InsertAsync(request);
            await _requestRepo.SaveChangesAsync();
        }

        // 🔹 Get All Requests
        public async Task<List<GetRequestDto>> GetAll()
        {
            return await _requestRepo.GetAll()
                .Include(x => x.Employee)
                .Include(x => x.Technician)
                .Include(x => x.Category)
                .Select(x => new GetRequestDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    EmployeeName = x.Employee.Name,
                    TechnicianName = x.Technician != null ? x.Technician.Name : null,
                    CategoryName = x.Category.Name,
                    Location = x.Location,
                    Status = x.status.ToString(),
                    CreatedAt = x.CreatedAt
                })
                .ToListAsync();
        }

        // 🔹 Assign Request to Technician
        public async Task AssignRequest(AssignRequestDto input)
        {
            var request = await _requestRepo.GetByIdAsync(input.RequestId);

            if (request == null)
                throw new Exception("Request not found");

            request.TechnicianId = input.TechnicianId;

            await _requestRepo.UpdateAsync(request);
            await _requestRepo.SaveChangesAsync();
        }

        // 🔹 Change Status + Save History
        public async Task ChangeStatus(ChangeStatusDto input)
        {
            var request = await _requestRepo.GetByIdAsync(input.RequestId);

            if (request == null)
                throw new Exception("Request not found");

            var history = new RequestHitory
            {
                Id = Guid.NewGuid(),
                RequestId = request.Id,
                UserId = _currentUser.UserId.Value,
                OldStatus = request.status,
                NewStatus = input.Status,
                Comment = input.Note,
                CreatedAt = DateTime.UtcNow
            };

            request.status = input.Status;

            await _historyRepo.InsertAsync(history);
            await _requestRepo.UpdateAsync(request);

            await _requestRepo.SaveChangesAsync();
        }

        public async Task Create(CreateRequestDto input)
        {
            var category = await _categoryRepo.GetAll()
                .FirstOrDefaultAsync(x => x.Name.ToLower() == input.CategoryName.ToLower());

            if (category == null)
                throw new Exception("Category not found");

            if (_currentUser.UserId == null)
                throw new Exception("User not logged in");

            var request = new Request
            {
                Id = Guid.NewGuid(),
                Title = input.Title,
                Description = input.Description,
                CategoryId = category.Id,
                Location = input.Location,
                EmployeeId = _currentUser.UserId.Value,
                CreatedAt = DateTime.UtcNow,
                status = RequestStatus.New
            };

            await _requestRepo.InsertAsync(request);
            await _requestRepo.SaveChangesAsync();
        }
    }
}


//using Application.Reposetories;
//using Application.Services.CurrentUserService;
//using Application.Services.RequestService.RequestDTOs;
//using Domain.Entites;
//using Domain.Enum;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Application.Services.RequestService
//{
//    public class RequestService : IRequestService
//    {
//        private readonly IGenericRepository<Request> _requestRepo;
//        private readonly IGenericRepository<RequestHitory> _historyRepo;
//        private readonly ICurrentUserService _currentUser;

//        public RequestService(
//            IGenericRepository<Request> requestRepo,
//            IGenericRepository<RequestHitory> historyRepo,
//            ICurrentUserService currentUser)
//        {
//            _requestRepo = requestRepo;
//            _historyRepo = historyRepo;
//            _currentUser = currentUser;
//        }

//        // 🔹 Create Request
//        public async Task CreateRequest(CreateRequestDto input)
//        {
//            var request = new Request
//            {
//                Id = Guid.NewGuid(),
//                Title = input.Title,
//                Description = input.Description,
//                CategoryId = input.CategoryId,
//                Location = input.Location,
//                EmployeeId = _currentUser.UserId.Value,
//                CreatedAt = DateTime.UtcNow,
//                status = RequestStatus.New
//            };

//            await _requestRepo.InsertAsync(request);
//            await _requestRepo.SaveChangesAsync();
//        }

//        // 🔹 Get All
//        public async Task<List<GetRequestDto>> GetAll()
//        {
//            var data = await _requestRepo.GetAll()
//                .Include(x => x.Employee)
//                .Include(x => x.Technician)
//                .Include(x => x.Category)
//                .Select(x => new GetRequestDto
//                {
//                    Id = x.Id,
//                    Title = x.Title,
//                    Description = x.Description,
//                    EmployeeName = x.Employee.Name,
//                    TechnicianName = x.Technician != null ? x.Technician.Name : null,
//                    CategoryName = x.Category.Name,
//                    Location = x.Location,
//                    Status = x.status.ToString(),
//                    CreatedAt = x.CreatedAt
//                })
//                .ToListAsync();

//            return data;
//        }

//        // 🔹 Assign
//        public async Task AssignRequest(AssignRequestDto input)
//        {
//            var request = await _requestRepo.GetByIdAsync(input.RequestId);

//            request.TechnicianId = input.TechnicianId;

//            await _requestRepo.UpdateAsync(request);
//            await _requestRepo.SaveChangesAsync();
//        }

//        // 🔹 Change Status
//        public async Task ChangeStatus(ChangeStatusDto input)
//        {
//            var request = await _requestRepo.GetByIdAsync(input.RequestId);

//            var history = new RequestHitory
//            {
//                Id = Guid.NewGuid(),
//                RequestId = request.Id,
//                UserId = _currentUser.UserId.Value,
//                OldStatus = request.status,
//                NewStatus = input.Status,
//                Comment = input.Note,
//                CreatedAt = DateTime.UtcNow
//            };

//            request.status = input.Status;

//            await _historyRepo.InsertAsync(history);
//            await _requestRepo.UpdateAsync(request);

//            await _requestRepo.SaveChangesAsync();
//        }

//        public async Task Create(CreateRequestDto input)
//        {
//            var request = new Request
//            {
//                Id = Guid.NewGuid(),
//                Title = input.Title,
//                Description = input.Description,
//                CategoryId = input.CategoryId,

//                Location = input.Location,
//                CreatedAt = DateTime.UtcNow,
//                status = RequestStatus.New
//            };

//            await _requestRepo.InsertAsync(request);

//            await _requestRepo.SaveChangesAsync();
//        }
//    }
//}
