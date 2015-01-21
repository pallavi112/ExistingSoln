﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProfile
{
    public class FooViewModel : INotifyPropertyChanged
    {
        #region Data

        bool? _isChecked = false;
        FooViewModel _parent;

        #endregion // Data

        #region CreateFoos

        public static List<FooViewModel> CreateFoos()
        {
            FooViewModel root = new FooViewModel("Modules:")
            {
                IsInitiallySelected = true,
                Children =
                {
                    new FooViewModel("Tools")
                    {
                        Children =
                        {
                            new FooViewModel("BookMark")
                            {
                                Children =
                                {
                                    new FooViewModel("Add")
                                }
                            },
                            new FooViewModel("Search ")
                            {
                                Children =
                                {
                                    new FooViewModel("Universal Search"),
                                    new FooViewModel("Advanced Search"),
                                    new FooViewModel("Spatial Search")
                                }
                            }
                        }
                    },
                    new FooViewModel("Widgets")
                    {
                        Children =
                        {
                            new FooViewModel("Draw")
                            {
                                Children =
                                {
                                    new FooViewModel("Drawing Mode")
                                    {
                                        Children =
                                        {
                                            new FooViewModel("Text"),
                                            new FooViewModel("Font Style"),
                                            new FooViewModel("Font Color")
                                        }
                                    }
                                }
                            },
                            new FooViewModel("Print"),
                            new FooViewModel("Directions"),
                            new FooViewModel("LayerList")
                            {
                                Children =
                                {
                                    new FooViewModel("Coverage Map")
                                    {
                                        Children =
                                        {
                                            new FooViewModel("Point Cloud"),
                                            new FooViewModel ("Imagery"),
                                            new FooViewModel("Video")

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            root.Initialize();
            return new List<FooViewModel> { root };
        }
        
        FooViewModel(string name)
        {
            this.Name = name;
            this.Children = new List<FooViewModel>();
        }

        void Initialize()
        {
            foreach (FooViewModel child in this.Children)
            {
                child._parent = this;
                child.Initialize();
            }
        }

        #endregion // CreateFoos

        #region Properties

        public List<FooViewModel> Children { get; private set; }

        public bool IsInitiallySelected { get; private set; }

        public string Name { get; private set; }

        #region IsChecked

        /// <summary>
        /// Gets/sets the state of the associated UI toggle (ex. CheckBox).
        /// The return value is calculated based on the check state of all
        /// child FooViewModels.  Setting this property to true or false
        /// will set all children to the same check state, and setting it 
        /// to any value will cause the parent to verify its check state.
        /// </summary>
        public bool? IsChecked
        {
            get { return _isChecked; }
            set { this.SetIsChecked(value, true, true); }
        }

        void SetIsChecked(bool? value, bool updateChildren, bool updateParent)
        {
            if (value == _isChecked)
                return;

            _isChecked = value;

            if (updateChildren && _isChecked.HasValue)
                this.Children.ForEach(c => c.SetIsChecked(_isChecked, true, false));

            if (updateParent && _parent != null)
                _parent.VerifyCheckState();

            this.OnPropertyChanged("IsChecked");
        }

        void VerifyCheckState()
        {
            bool? state = null;
            for (int i = 0; i < this.Children.Count; ++i)
            {
                bool? current = this.Children[i].IsChecked;
                if (i == 0)
                {
                    state = current;
                }
                else if (state != current)
                {
                    state = null;
                    break;
                }
            }
            this.SetIsChecked(state, false, true);
        }

        #endregion // IsChecked

        #endregion // Properties

        #region INotifyPropertyChanged Members

        void OnPropertyChanged(string prop)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
