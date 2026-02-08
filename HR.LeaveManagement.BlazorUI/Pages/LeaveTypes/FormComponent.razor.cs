using HR.LeaveManagement.BlazorUI.Models.LeaveTypes;
using Microsoft.AspNetCore.Components;

namespace HR.LeaveManagement.BlazorUI.Pages.LeaveTypes
{
    public partial class FormComponent
    {
        [Parameter] public bool Disabled { get; set; }
        [Parameter] public LeaveTypeVM LeaveType { get; set; }
        [Parameter] public string ButtonText { get; set; }
        [Parameter]public EventCallback OnValidSubmit { get; set; }
    }
}