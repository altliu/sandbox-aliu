using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SSGenerator
{
    public partial class EventsEditor : Form
    {
        public EventsEditor()
        {
            InitializeComponent();
            loadManager();
            // TODO: put this somewhere cleaner
            this.Closing += delegate
                {
                    EventManager.SaveManager();
                };
        }

        #region Private Methods
        
        private void loadManager()
        {
            EventManager.LoadManager();
            foreach (EventDataWrapper eventDataWrapper in EventManager.EventDatabase.EventDataWrappers)
            {
                if (eventDataWrapper.Active)
                {
                    _activeListbox.Items.Add(eventDataWrapper);
                }
                else
                {
                    _inactiveListbox.Items.Add(eventDataWrapper);
                }
            }
        }

        private void _inactiveButton_Click(object sender, EventArgs e)
        {
            EventDataWrapper instance = _activeListbox.SelectedItem as EventDataWrapper;
            if (instance != null)
            {
                instance.Active = false;
                _activeListbox.Items.Remove(instance);
                _inactiveListbox.Items.Add(instance);
                EventManager.SaveManager();
            }
        }

        private void _activeButton_Click(object sender, EventArgs e)
        {
            EventDataWrapper instance = _inactiveListbox.SelectedItem as EventDataWrapper;
            if (instance != null)
            {
                instance.Active = true;
                _inactiveListbox.Items.Remove(instance);
                _activeListbox.Items.Add(instance);
                EventManager.SaveManager();
            }
        }

        private void _newButton_Click(object sender, EventArgs e)
        {
            EventDataWrapper eventData = new EventDataWrapper(EventDefinitionManager.EventDefinition);

            using (EventInstanceEditor instanceEditor = new EventInstanceEditor(eventData))
            {
                instanceEditor.ShowInTaskbar = false;
                instanceEditor.MaximizeBox = false;
                instanceEditor.MinimizeBox = false;

                instanceEditor.StartPosition = FormStartPosition.CenterParent;
                if (instanceEditor.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                EventDataWrapper instance = instanceEditor.Event;
                instance.Active = true;
                EventManager.EventDatabase.EventDataWrappers.Add(instance);
                _activeListbox.Items.Add(instance);
                EventManager.SaveManager();
            }
        }

        private void _editButton_Click(object sender, EventArgs e)
        {
            EventDataWrapper eventData = _activeListbox.SelectedItem as EventDataWrapper;
            if (eventData == null)
            {
                eventData = _inactiveListbox.SelectedItem as EventDataWrapper;
            }

            if (eventData != null)
            {
                using (EventInstanceEditor instanceEditor = new EventInstanceEditor(eventData))
                {
                    instanceEditor.ShowInTaskbar = false;
                    instanceEditor.MaximizeBox = false;
                    instanceEditor.MinimizeBox = false;

                    instanceEditor.StartPosition = FormStartPosition.CenterParent;
                    instanceEditor.ShowDialog(this);
                    EventManager.SaveManager();
                }
            }
        }

        private void _deleteButton_Click(object sender, EventArgs e)
        {
            EventDataWrapper eventData = _activeListbox.SelectedItem as EventDataWrapper;
            if (eventData != null)
            {
                _activeListbox.Items.Remove(eventData);
                EventManager.EventDatabase.EventDataWrappers.Remove(eventData);
                EventManager.SaveManager();
                return;
            }

            eventData = _inactiveListbox.SelectedItem as EventDataWrapper;
            if (eventData != null)
            {
                _inactiveListbox.Items.Remove(eventData);
                EventManager.EventDatabase.EventDataWrappers.Remove(eventData);
                EventManager.SaveManager();
                return;
            }
        }

        #endregion
    }
}