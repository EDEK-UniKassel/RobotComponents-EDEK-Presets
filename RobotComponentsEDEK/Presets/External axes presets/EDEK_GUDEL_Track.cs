// System Libs
using System.Collections.Generic;
// Rhino Libs
using Rhino.Geometry;
// Robot Components Libs
using RobotComponents.Definitions;
using RobotComponents.Utils;

namespace RobotComponentsEDEK.Presets.ExternalAxes
{
    /// <summary>
    /// Defines the GUDEL Track external linear axis
    /// </summary>
    public static class EDEK_GUDEL_Track
    {
        /// <summary>
        /// Defines the GUDEL track external linear axis.
        /// </summary>
        /// <returns> Returns the external linear axis preset. </returns>
        public static ExternalLinearAxis GetExternalLinearAxis()
        {
            string name = Name;
            Vector3d axis = Axis;
            Plane axisPlane = AxisPlane;
            Interval axisLimit = AxisLimit;
            List<Mesh> meshes = GetMeshes();

            ExternalLinearAxis externalLinearAxis = new ExternalLinearAxis(name, Plane.WorldXY, axis, axisLimit, meshes[0], meshes[1]);
            Transform trans = Transform.PlaneToPlane(Plane.WorldXY, axisPlane);
            externalLinearAxis.Transform(trans);

            return externalLinearAxis;
        }

        /// <summary>
        /// Defines the GUDEL track external linear axis
        /// With this method you can overwrite the properties 
        /// </summary>
        /// <param name="name"> The name of the external linear axis. </param>
        /// <param name="positionPlane"> The position of the axis plane in world coordinate space as plane. </param>
        /// <param name="axis"> The axis direction as a vector. </param>
        /// <param name="axisLimit"> The axis limits as a domain. </param>
        /// <returns> Returns the external linear axis preset. </returns>
        public static ExternalLinearAxis GetExternalLinearAxis(string name, Plane positionPlane, Vector3d axis, Interval axisLimit)
        {
            List<Mesh> meshes = GetMeshes();

            ExternalLinearAxis externalLinearAxis = new ExternalLinearAxis(name, Plane.WorldXY, axis, axisLimit, meshes[0], meshes[1]);
            Transform trans = Transform.PlaneToPlane(Plane.WorldXY, positionPlane);
            externalLinearAxis.Transform(trans);

            return externalLinearAxis;
        }

        /// <summary>
        /// Defines the base and link meshes a robot coordinate space. 
        /// </summary>
        /// <returns> Returns a list with meshes. </returns>
            public static List<Mesh> GetMeshes()
        {
            List<Mesh> meshes = new List<Mesh>() { };
            string linkString;

            // Base
            linkString = RobotComponentsEDEK.Properties.Resources.GUDEL_track_link_0;
            meshes.Add((Mesh)HelperMethods.ByteArrayToObject(System.Convert.FromBase64String(linkString)));
            // Axis 1
            linkString = RobotComponentsEDEK.Properties.Resources.GUDEL_track_link_1;
            meshes.Add((Mesh)HelperMethods.ByteArrayToObject(System.Convert.FromBase64String(linkString)));

            return meshes;
        }

        /// <summary>
        /// Predefined name
        /// </summary>
        public static string Name
        {
            get { return "M8DM1"; }
        }

        /// <summary>
        /// Predefined axis direction
        /// </summary>
        public static Vector3d Axis
        {
            get { return new Vector3d(1, 0, 0); }
        }

        /// <summary>
        /// Predefined axis plane
        /// </summary>
        public static Plane AxisPlane
        {
            get { return new Plane(new Point3d(0.0, 0.0, 2565), new Vector3d(0, 1, 0), new Vector3d(1, 0, 0)); }
        }

        /// <summary>
        /// Predefined axis limit
        /// </summary>
        public static Interval AxisLimit
        {
            get { return new Interval(-5, 9620); }
        }
    }
}
