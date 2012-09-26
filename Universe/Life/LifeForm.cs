﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Universe.Interface;
using Universe.Entity;
using System.Threading;

namespace Universe.Life
{
    public class LifeForm : iLifeForm, IDisposable
    {
        #region Public Atributes
        public DNA dna;
        #endregion

        #region IDisposable
        private bool disposing;
 
        //
        // … resto del código …
        //
 
        /// <summary>
        /// Método de IDisposable para desechar la clase.
        /// </summary>
        public void Dispose()
        {
            // Llamo al método que contiene la lógica
            // para liberar los recursos de esta clase.
            Dispose(true);
        }
 
        /// <summary>
        /// Método sobrecargado de Dispose que será el que
        /// libera los recursos, controla que solo se ejecute
        /// dicha lógica una vez y evita que el GC tenga que
        /// llamar al destructor de clase.
        /// </summary>
        /// <param name=”b”></param>
        protected virtual void Dispose(bool b)
        {
            // Si no se esta destruyendo ya…
            if (!disposing)
            {
                // La marco como desechada ó desechandose,
                // de forma que no se puede ejecutar este código
                // dos veces.
                disposing = true;
 
                // Indico al GC que no llame al destructor
                // de esta clase al recolectarla.
                GC.SuppressFinalize(this);
 
                // … libero los recursos… 
            }
        }
 
        /// <summary>
        /// Destructor de clase.
        /// En caso de que se nos olvide “desechar” la clase,
        /// el GC llamará al destructor, que tambén ejecuta la lógica
        /// anterior para liberar los recursos.
        /// </summary>
        ~LifeForm()
        {
            // Llamo al método que contiene la lógica
            // para liberar los recursos de esta clase.
            Dispose(true);
        }        
        #endregion

        #region Constructor
        public LifeForm()
        {
        }

        public LifeForm(DNA aDna)
        {
        }

        public LifeForm(DNA aDna1, DNA aDna2)
        {
        }
        #endregion
    }
}
