using BusinessLogic.Interfaces;
using DataLayer.Interfaces;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class LocationService : ILocationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LocationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Location>> GetAllLocationsAsync()
        {
            return await _unitOfWork.Locations.GetAllAsync();
        }

        public async Task<Location> GetLocationByIdAsync(int id)
        {
            return await _unitOfWork.Locations.GetByIdAsync(id);
        }

        public async Task AddLocationAsync(Location location)
        {
            await _unitOfWork.Locations.AddAsync(location);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateLocationAsync(Location location)
        {
            await _unitOfWork.Locations.UpdateAsync(location);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteLocationAsync(int id)
        {
            await _unitOfWork.Locations.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }

}
