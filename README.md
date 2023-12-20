# How to apply the background color when mouse hover on SfDataGrid in .NET MAUI

The .NET MAUI DataGrid allows you to change the datagrid background color when hover on the cell in WinUI and MacOs platforms.

```Behavior.cs
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
```

![Output for the above code](MouseHover.png)

Please find the sample from the below link.

[View sample in Github](https://github.com/SyncfusionExamples/How-to-apply-the-background-color-when-mouse-hover-on-SfDataGrid-in-.NET-MAUI-/tree/master)

Take a moment to explore this [documentation](https://help.syncfusion.com/maui/datagrid/overview), where you can find more information about Syncfusion .NET MAUI DataGrid (SfDataGrid) with code examples. Please refer to this [link](https://www.syncfusion.com/maui-controls/maui-datagrid) to learn about the essential features of Syncfusion .NET MAUI DataGrid (SfDataGrid).

##### Conclusion

I hope you enjoyed learning about How to apply the background color when mouse hover on SFDataGrid in .NET MAUI DataGrid (SfDataGrid).

You can refer to our [.NET MAUI DataGrid’s feature tour](https://www.syncfusion.com/maui-controls/maui-datagrid) page to learn about its other groundbreaking feature representations. You can also explore our [.NET MAUI DataGrid Documentation](https://help.syncfusion.com/maui/datagrid/getting-started) to understand how to present and manipulate data. 
For current customers, you can check out our .NET MAUI components on the [License and Downloads](https://www.syncfusion.com/sales/teamlicense) page. If you are new to Syncfusion, you can try our 30-day [free trial](https://www.syncfusion.com/downloads/maui) to explore our .NET MAUI DataGrid and other .NET MAUI components.

If you have any queries or require clarifications, please let us know in the comments below. You can also contact us through our [support forums](https://www.syncfusion.com/forums), [Direct-Trac](https://support.syncfusion.com/create) or [feedback portal](https://www.syncfusion.com/feedback/maui?control=sfdatagrid), or the feedback portal. We are always happy to assist you!
