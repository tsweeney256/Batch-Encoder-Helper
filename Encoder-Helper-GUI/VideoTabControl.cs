﻿/*Batch Encoder Helper
Copyright (C) 2015 Thomas Sweeney

This file is part of Batch Encoder Helper.
Batch Encoder Helper is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

Batch Encoder Helper is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
 
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encoder_Helper_GUI
{
    public partial class VideoTabControl : UserControl
    {
        public string TextBox_x264_Args_Text {
            get { return TextBox_x264_Args.Text; }
            set { TextBox_x264_Args.Text = value; }
        }
        public int ComboBox_Encoder_SelectedIndex
        {
            get { return ComboBox_Encoder.SelectedIndex; }
            set { ComboBox_Encoder.SelectedIndex = value;  }
        }
        public string FileNamePrefixText
        {
            get { return textBoxPrefix.Text; }
            set { textBoxPrefix.Text = value; }
        }
        public string FileNameBodyText
        {
            get { return textBoxBody.Text; }
            set { textBoxBody.Text = value; }
        }
        public string FileNameSuffixText
        {
            get { return textBoxSuffix.Text; }
            set { textBoxSuffix.Text = value; }
        }

        public VideoTabControl()
        {
            InitializeComponent();
        }

        public void AttachToNewTab(TabControl tc)
        {
            tc.TabPages.Insert(tc.TabCount - 1, tc.TabCount.ToString());
            var lastPage = tc.TabPages[tc.TabCount - 2];
            attachCommon(lastPage);
            tc.TabPages[tc.TabCount - 2].UseVisualStyleBackColor = true;
            tc.SelectTab(tc.TabCount - 2);
        }

        //hack to get around TabPages.Insert() refusing to work in constructors
        public void AttachToLastTab(TabControl tc)
        {
            tc.TabPages.Add((tc.TabCount + 1).ToString());
            var lastPage = tc.TabPages[tc.TabCount - 1];
            attachCommon(lastPage);
            tc.TabPages[tc.TabCount - 1].UseVisualStyleBackColor = true;
        }

        private void attachCommon(TabPage lastPage)
        {
            panelVideoTab.Size = lastPage.Size;
            lastPage.Controls.Add(panelVideoTab);
        }
    }
}
