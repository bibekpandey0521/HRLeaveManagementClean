using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Models.LeaveTypes;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace HR.LeaveManagement.BlazorUI.Pages.LeaveTypes
{
    public partial class Index
    {
        [Inject]
        NavigationManager NavigationManager { get; set; }
      
        [Inject]
        public ILeaveTypeService LeaveTypeService { get; set; }
        [Inject]
        public ILeaveAllocationService LeaveAllocationService { get; set; } 

        public string Message { get; private set; }

        public List<LeaveTypeVM> LeaveTypes { get; private set; }
        protected void CreateLeaveType()
        {
            NavigationManager.NavigateTo("/leavetypes/create");
        }
        protected void AllocateLeaveType(int id)
        {
            // Use Leave Allocation Service here
            LeaveAllocationService.CreateLeaveAllocations(id);
        }

        //protected async Task AllocateLeaveType(int id) 
        //{
        //    var response = await LeaveAllocationService.CreateLeaveAllocations(id);
        //}
        protected void EditLeaveType(int id)
        {
            NavigationManager.NavigateTo($"/leaveTypes/edit/{id}");
        }
        protected void DetailsLeaveType(int id)
        {
            NavigationManager.NavigateTo($"/leaveTypes/details/{id}");
        }
        protected async Task DeleteLeaveType(int id)
        {
            var response = await LeaveTypeService.DeleteLeaveType(id);
            if (response.Success)
            {
                StateHasChanged();
            }
            else
            {
                Message = response.Message;
            }
        }
        protected override async Task OnInitializedAsync()
        {
            LeaveTypes = await LeaveTypeService.GetLeaveTypes();
        }
    }
}