using Syncfusion.Maui.DataGrid;
using Syncfusion.Maui.DataGrid.DataPager;
using Syncfusion.Maui.DataGrid.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridSample.Behaviors
{
    public class DataGridBehavior : Behavior<ContentPage>
    {
        private SfDataGrid? dataGrid;
        private EmployeeViewModel? employeeViewModel;

        protected override void OnAttachedTo(ContentPage page)
        {
            base.OnAttachedTo(page);
            employeeViewModel = new EmployeeViewModel();
            dataGrid = page.FindByName<SfDataGrid>("dataGrid");
            dataGrid.ItemsSource = employeeViewModel.Employees;
#if WINDOWS || MACCATALYST
            dataGrid.CellHovered += DataGrid_CellHovered;
            dataGrid.CellExited += DataGrid_CellExited;
#endif
        }

#if WINDOWS || MACCATALYST
        private void DataGrid_CellExited(object? sender, DataGridCellExitedEventArgs e)
        {
            if(this.dataGrid != null && this.dataGrid.BackgroundColor != Colors.Transparent)
            {
                this.dataGrid.BackgroundColor = Colors.Transparent;
            } 
        }

        private void DataGrid_CellHovered(object? sender, DataGridCellHoveredEventArgs e)
        {
            if (this.dataGrid != null && this.dataGrid.BackgroundColor == Colors.Transparent)
            {
                this.dataGrid.BackgroundColor = Colors.Red;
            }
        }
#endif

        protected override void OnDetachingFrom(ContentPage page)
        {
            base.OnDetachingFrom(page);

#if WINDOWS || MACCATALYST
            if (dataGrid != null)
            {
                dataGrid!.CellHovered -= DataGrid_CellHovered;
                dataGrid.CellExited -= DataGrid_CellExited;
            }
#endif
        }
    }
}
