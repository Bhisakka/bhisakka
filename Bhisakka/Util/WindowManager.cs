using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bhisakka.Util
{
    internal class WindowManager
    {
        private static WindowManager _instance;

        public static WindowManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new WindowManager();
            }

            return _instance;
        }

        private readonly Dictionary<Type, Form> _openForms = new Dictionary<Type, Form>();

        private WindowManager() { }

        public void RegisterForm(Form existingForm)
        {
            Type formType = existingForm.GetType();

            if (!_openForms.ContainsKey(formType))
            {
                _openForms[formType] = existingForm;
                existingForm.FormClosed += OnFormClosed;

            }
        }

        public void Show<T>() where T : Form, new()
        {
            Type formType = typeof(T);

            if (_openForms.ContainsKey(formType) && !_openForms[formType].IsDisposed)
            {
                _openForms[formType].Show();
                _openForms[formType].BringToFront();
            }
            else
            {
                T newForm = new T();

                _openForms[formType] = newForm;

                newForm.FormClosed += OnFormClosed;

                newForm.Show();
            }
        }

        public DialogResult ShowDialog<T>() where T : Form, new()
        {
            Type formType = typeof(T);

            if (_openForms.ContainsKey(formType) && !_openForms[formType].IsDisposed)
            {
                _openForms[formType].BringToFront();
                return _openForms[formType].DialogResult;
            }

            T newForm = new T();

            _openForms[formType] = newForm;

            DialogResult result = newForm.ShowDialog();

            _openForms.Remove(formType);
            newForm.Dispose();

            return result;
        }

        public void Hide<T>() where T : Form
        {
            Type formType = typeof(T);
            if (_openForms.ContainsKey(formType) && !_openForms[formType].IsDisposed)
            {
                _openForms[formType].Hide();
            }
        }

        public void Close<T>() where T : Form
        {
            Type formType = typeof(T);
            if (_openForms.ContainsKey(formType) && !_openForms[formType].IsDisposed)
            {
                _openForms[formType].Close();
            }
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is Form closedForm)
            {
                Type formType = closedForm.GetType();

                if (_openForms.ContainsKey(formType))
                {
                    _openForms.Remove(formType);
                }
            }

            if (_openForms.Count == 0)
            {
                Application.Exit();
            }
        }
    }
}
