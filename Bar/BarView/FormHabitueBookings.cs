using BarServiceDAL.BindingModels;
using BarServiceDAL.ViewModels;
using BarServiceDAL.Interfaces;
using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;
using System.Collections.Generic;


namespace BarView
{
    public partial class FormHabitueBookings : Form
    {
        public FormHabitueBookings()
        {
            InitializeComponent();
        }
        private void buttonMake_Click(object sender, EventArgs e)
        {
            if (dateTimePickerFrom.Value.Date >= dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                ReportParameter parameter = new ReportParameter("RecordParameterPeriod",
                    "c " + dateTimePickerFrom.Value.ToShortDateString() +
                    " по " + dateTimePickerTo.Value.ToShortDateString());
                recordViewer.LocalReport.SetParameters(parameter);
                List<HabitueBookingsModel> response = APIClient.PostRequest<RecordBindingModel,
                List<HabitueBookingsModel>>("api/Record/GetHabitueBookings", new RecordBindingModel
                {
                    DateFrom = dateTimePickerFrom.Value,
                    DateTo = dateTimePickerTo.Value
                });
                ReportDataSource source = new ReportDataSource("DataSetBookings",
                response);
                recordViewer.LocalReport.DataSources.Add(source);
                recordViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
        private void buttonToPdf_Click(object sender, EventArgs e)
        {
            if (dateTimePickerFrom.Value.Date >= dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "pdf|*.pdf"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    APIClient.PostRequest<RecordBindingModel,
                    bool>("api/Record/SaveHabitueBookings", new RecordBindingModel
                    {
                        FileName = sfd.FileName,
                        DateFrom = dateTimePickerFrom.Value,
                        DateTo = dateTimePickerTo.Value
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }
    }
}
