using System;
using System.Collections.Generic;
using System.Linq;
using Universe.Interface;
using Universe.Entity;
using System.Threading;
using Universe.Misc;

namespace Universe.Life
{
    public class LifeForm : iLifeForm, IDisposable, IComparable
    {
        #region Public Atributes
        public DNASequence dna;
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
        public DateTime BirthDate;
        public DateTime LifeDate;
        public LifeFormTypes Type;
        #endregion

        #region Private Atributes
        private int Ticks;
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
                FinishMainTask();
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

        #region IComparable
        public int CompareTo(object obj)
        {
            if (obj is LifeForm)
                return this.dna.Id.CompareTo((obj as LifeForm).dna.Id);
            throw new ArgumentException("Object is not a LifeForm");
        }
        #endregion

        #region iLifeForm
        public virtual void MainTask()
        {
            //Tarea repetitiva que se debe implementar
        }

        public virtual void DoMainTask()
        {
            while (InProgress)
            {
                MainTask();
                Thread.Sleep(GetActionInterval());
            }
        }

        public virtual void BeginMainTask() 
        {
            _InProgress = true;
            mind = new Thread(DoMainTask);
            mind.Start();
        }

        public virtual void FinishMainTask()
        {
            _InProgress = false;
            mind = null;
        }

        public virtual void Dead()
        {
            FinishMainTask();
            NotifyMasterLifeForm(NotificationType.Dead, this);
        }

        public virtual void NotifyMasterLifeForm(NotificationType aNotifyType, LifeForm aLifeForm)
        {
            if (_Master != null)
                _Master.NotifyMasterLifeForm(aNotifyType, aLifeForm);
            else
                ManageMasterNotification(aNotifyType, aLifeForm);
        }

        public virtual void ManageMasterNotification(NotificationType aNotifyType, LifeForm aLifeForm)
        {
        }

        public virtual int GetAttribute(SkillTypes aSkill)
        {
            //TODO
            return 500;
        }
        #endregion

        #region Self-management
        private static void ReGenerateADN(LifeFormTypes aLifeFormType, DNASequence aDna)
        {
            if (aDna != null)
            {
                dna = new DNASequence(aDna);
            }
            else
            {
            }
        }
        #endregion


        #region Constructor
        public LifeForm(LifeForm aMaster, LifeFormTypes aLifeFormType)
        {
            _Master = aMaster;
            Type = aLifeFormType;
            ReGenerateADN(aLifeFormType, null);
            BeginMainTask();
        }

        public LifeForm(LifeForm aMaster, LifeFormTypes aLifeFormType, DNASequence aDna)
        {
            _Master = aMaster;
            Type = aLifeFormType;
            ReGenerateADN(aLifeFormType, aDna);
            BeginMainTask();
        }
        #endregion
    }
}
