using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProfile
{
    public class MapTreeViewModel : INotifyPropertyChanged
    {
        #region Data

        bool? _isChecked = false;
        MapTreeViewModel _parent;

        #endregion // Data

        #region MapTree

        public static List<MapTreeViewModel> CreateMapTree()
        {
            MapTreeViewModel root1 = new MapTreeViewModel("Maps")
            {
                IsInitiallySelected = true,
                Children =
                {
                    new MapTreeViewModel("LGEKU:")
                    {
                        Children = 
                        {
                            new MapTreeViewModel("Basemap")
                            {
                                Children =
                                {
                                    //new MapTreeViewModel("Kentucky Historic Sites"),
                                    //new MapTreeViewModel("Airports"),
                                    //new MapTreeViewModel("Helipads"),
                                    //new MapTreeViewModel("Public Schools"),
                                    //new MapTreeViewModel("Kentucky Public Schools"),
                                    //new MapTreeViewModel("Kentucky Public School Districts"),
                                    //new MapTreeViewModel("Kentucky State Parks"),
                                    //new MapTreeViewModel("Land Cover"),
                                    //new MapTreeViewModel("Developed Areas"),
                                    //new MapTreeViewModel("High Density"),
                                    //new MapTreeViewModel("Medium Density"),
                                    //new MapTreeViewModel("Low Density"),
                                    //new MapTreeViewModel("Open Space"),
                                    //new MapTreeViewModel("Vegetation"),
                                    //new MapTreeViewModel("Shrub/Scrub"),
                                    //new MapTreeViewModel("Herbaceuous"),
                                    //new MapTreeViewModel("Barren Land"),
                                    //new MapTreeViewModel("Forests"),
                                    //new MapTreeViewModel("Deciduous"),
                                    //new MapTreeViewModel("Evergreen"),
                                    //new MapTreeViewModel("Mixed"),
                                    //new MapTreeViewModel("Agriculture"),
                                    //new MapTreeViewModel("Cultivated Crops"),
                                    //new MapTreeViewModel("Hay/Pasture"),
                                    //new MapTreeViewModel("Wetlands"),
                                    //new MapTreeViewModel("Emergent Herbaceuous"),
                                    //new MapTreeViewModel("Woody"),
                                    //new MapTreeViewModel("Open Water"),
                                    //new MapTreeViewModel("Counties")
                                }                    
                            },
                            new MapTreeViewModel("Environmental")
                            {
                                Children =
                                {
                            
                                }
                            },
                            new MapTreeViewModel("ExportWebMap")
                            {
                            }
                        }
                    },
                    new MapTreeViewModel("LONESTAR")
                    {
                        Children = 
                        {
                            new MapTreeViewModel("Basemap")
                            {
                                Children =
                                {
                                    //new MapTreeViewModel("Texas Parks"),
                                    //new MapTreeViewModel("Texas Cities"),
                                    //new MapTreeViewModel("Texas School Districts"),
                                    //new MapTreeViewModel ("Commissioner Precincts"),
                                    //new MapTreeViewModel ("Texas Counties"),
                                    //new MapTreeViewModel ("County Line (100m-1m)"),
                                    //new MapTreeViewModel("County Line (1m-350k)"),
                                    //new MapTreeViewModel ("County Line (350k-0)"),
                                    //new MapTreeViewModel ("Texas Cultural")
                                }
                            },
                            new MapTreeViewModel ("EditFeatures")
                            {},
                            new MapTreeViewModel ("Engineering")
                            {},
                            new MapTreeViewModel ("Environmental")
                        }
                    }
                }
                
            };

            root1.Initialize();
            return new List<MapTreeViewModel> { root1 };
        }

        MapTreeViewModel(string name)
        {
            this.Name = name;
            this.Children = new List<MapTreeViewModel>();
        }

        void Initialize()
        {
            foreach (MapTreeViewModel child in this.Children)
            {
                child._parent = this;
                child.Initialize();
            }
        }

        #endregion // CreateFoos

        #region Properties

        public List<MapTreeViewModel> Children { get; private set; }

        public bool IsInitiallySelected { get; private set; }

        public string Name { get; private set; }

        #region IsChecked

        /// <summary>
        /// Gets/sets the state of the associated UI toggle (ex. CheckBox).
        /// The return value is calculated based on the check state of all
        /// child MapTreeViewModels.  Setting this property to true or false
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
