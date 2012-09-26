using System;
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
        public Thread mind;
        public bool InProgress
        {
            get
            {
                return _InProgress;
            }
            set
            {
                if (_InProgress == value)
                    return;
                _InProgress = value;
            }
        }
        public LifeForm Master
        {
            get
            {
                return _Master;
            }
            set
            {
                if (_Master == value)
                    return;
                _Master = value;
            }
        }
        #endregion

        #region Private Atributes
        private bool _InProgress;
        private LifeForm _Master;
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
                this.FinishMainTask();
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

        #region iLifeForm
        public virtual void MainTask()
        {
            //Tarea repetitiva que se debe implementar
        }

        public virtual void DoMainTask()
        {
            while (this.InProgress)
            {
                this.MainTask();
                Thread.Sleep(this.GetActionInterval());
            }
        }

        public virtual void BeginMainTask() 
        {
            this._InProgress = true;
            this.mind = new Thread(this.DoMainTask);
            this.mind.Start();
        }

        public virtual void FinishMainTask()
        {
            this._InProgress = false;
            this.mind = null;
        }

        public virtual int GetActionInterval()
        {
            int x = 500;
            //TODO
            return x;
        }
        #endregion

        #region Constructor
        public LifeForm(LifeForm aMaster)
        {
            this._Master = aMaster;
            this.BeginMainTask();
        }

        public LifeForm(LifeForm aMaster, DNA aDna)
        {
            this._Master = aMaster;
            this.BeginMainTask();
        }

        public LifeForm(LifeForm aMaster, DNA aDna1, DNA aDna2)
        {
            this._Master = aMaster;
            this.BeginMainTask();
        }
        #endregion
    }
}
