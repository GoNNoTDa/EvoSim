﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Universe.Entity;

namespace EvoSimApp
{
    public partial class Form1 : Form
    {
        private Master Dios;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dios = new Master();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dios.TimeFreeze();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dios.ActivateTime();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dios.Dispose();
            Dios = null;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Dios != null)
            {
                label1.Text = Dios.WhatTimeIsIt().ToString();
            }
            else
            {
                label1.Text = "En espera...";
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dios.Dispose();
            Dios = null;
        }
    }
}
