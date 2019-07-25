using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Telerik.Windows.Controls.Diagrams;

namespace DiagramToolBox
{
    public class MyShape
    {
        public Geometry Geometry { get; set; }
        public string Header { get; set; }
    }
    
    public class MyGallery
    {
        public string Header { get; set; }
        public ObservableCollection<MyShape> Shapes { get; set; }
        public MyGallery()
        {
            this.Shapes = new ObservableCollection<MyShape>();
        }
    }
        
    public class MainViewModel
    {
        public static String Columns = "5";
        public ObservableCollection<MyGallery> Items { get; set; }
        public MainViewModel()
        {
            this.Items = new ObservableCollection<MyGallery>();
            //create and populate the first custom gallery
            MyGallery firstGallery = new MyGallery { Header = "First Gallery" };
            firstGallery.Shapes.Add(new MyShape
            {
                Header = "Shape 1.1",
                Geometry = ShapeFactory.GetShapeGeometry(CommonShapeType.CloudShape)
            });
            firstGallery.Shapes.Add(new MyShape
            {
                Header = "Shape 1.2",
                Geometry = ShapeFactory.GetShapeGeometry(CommonShapeType.EllipseShape)
            });
            firstGallery.Shapes.Add(new MyShape
            {
                Header = "Shape 1.3",
                Geometry = ShapeFactory.GetShapeGeometry(CommonShapeType.HexagonShape)
            });
            firstGallery.Shapes.Add(new MyShape
            {
                Header = "Shape 1.4",
                Geometry = ShapeFactory.GetShapeGeometry(CommonShapeType.HexagonShape)
            });
            firstGallery.Shapes.Add(new MyShape
            {
                Header = "Shape 1.5",
                Geometry = ShapeFactory.GetShapeGeometry(CommonShapeType.HexagonShape)
            });
            this.Items.Add(firstGallery);

            //create and populate the second custom gallery
            MyGallery secondGallery = new MyGallery { Header = "Second Gallery" };
            secondGallery.Shapes.Add(new MyShape
            {
                Header = "Shape 2.1",
                Geometry = ShapeFactory.GetShapeGeometry(FlowChartShapeType.CardShape)
            });
            secondGallery.Shapes.Add(new MyShape
            {
                Header = "Shape 2.2",
                Geometry = ShapeFactory.GetShapeGeometry(FlowChartShapeType.Database1Shape)
            });
            secondGallery.Shapes.Add(new MyShape
            {
                Header = "Shape 2.3",
                Geometry = ShapeFactory.GetShapeGeometry(FlowChartShapeType.CollateShape)
            });
            secondGallery.Shapes.Add(new MyShape
            {
                Header = "Shape 2.4",
                Geometry = ShapeFactory.GetShapeGeometry(FlowChartShapeType.CollateShape)
            });
            secondGallery.Shapes.Add(new MyShape
            {
                Header = "Shape 2.5",
                Geometry = ShapeFactory.GetShapeGeometry(FlowChartShapeType.CollateShape)
            });

            this.Items.Add(secondGallery);
        }
    }
}
