using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR9
{
    public partial class MainForm : Form
    {
        private List<Car> mCarsList;

        public MainForm()
        {
            InitializeComponent();
            mCarsList = new List<Car>();

            RefreshScreen();
        }

        private void UpdateListBox()
        {
            numbersListBox.Items.Clear();
            mCarsList.ForEach(carInfo => numbersListBox.Items.Add(carInfo.mNumber));
        }

        private void ChangeStateOfGroupBoxControls(bool isEnabled)
        {
            numTextBox.Enabled = isEnabled;
            modelTextBox.Enabled = isEnabled;
            colorComboBox.Enabled = isEnabled;
            fioTextBox.Enabled = isEnabled;

            saveButton.Enabled = isEnabled;
            revertButton.Enabled = isEnabled;

            removeButton.Enabled = isEnabled;
        }

        private void RefreshScreen()
        {
            UpdateListBox();

            numberTextBox.Text = "";
            numTextBox.Text = "";
            modelTextBox.Text = "";
            colorComboBox.Text = "";
            fioTextBox.Text = "";

            ChangeStateOfGroupBoxControls(false);
        }

        private void numberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar != (char)Keys.Enter)
            {
                return;
            }

            if(!Utils.IsNumberValid(numberTextBox.Text))
            {
                return;
            }

            if (mCarsList.Any(carInfo => carInfo.mNumber == numberTextBox.Text))
            {
                return;
            }

            mCarsList.Add(new Car(numberTextBox.Text));
            UpdateListBox();
        }

        private void numbersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(numbersListBox.SelectedIndex == -1)
            {
                ChangeStateOfGroupBoxControls(false);
                return;
            }
            ChangeStateOfGroupBoxControls(true);

            var carInfo = mCarsList.ElementAt(numbersListBox.SelectedIndex);
            numTextBox.Text = carInfo.mNumber;
            modelTextBox.Text = carInfo.mModel;
            colorComboBox.Text = Utils.ConvertColorToString(carInfo.mColor);
            fioTextBox.Text = carInfo.mFio;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            mCarsList.RemoveAt(numbersListBox.SelectedIndex);
            RefreshScreen();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var carInfo = mCarsList.ElementAt(numbersListBox.SelectedIndex);
            carInfo.mNumber = numTextBox.Text;
            carInfo.mModel = modelTextBox.Text;
            carInfo.mColor = Utils.ConvertStringToColor(colorComboBox.Text);
            carInfo.mFio = fioTextBox.Text;

            UpdateListBox();
        }

        private void revertButton_Click(object sender, EventArgs e)
        {
            var carInfo = mCarsList.ElementAt(numbersListBox.SelectedIndex);
            numTextBox.Text = carInfo.mNumber;
            modelTextBox.Text = carInfo.mModel;
            colorComboBox.Text = Utils.ConvertColorToString(carInfo.mColor);
            fioTextBox.Text = carInfo.mFio;
        }
    }
}
