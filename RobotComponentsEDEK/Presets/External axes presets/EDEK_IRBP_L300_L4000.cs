﻿// System Libs
using System.Collections.Generic;
// Rhino Libs
using Rhino.Geometry;
// Robot Components Libs
using RobotComponents.BaseClasses.Definitions;
using RobotComponents.Utils;

namespace RobotComponentsEDEK.Presets.ExternalAxes
{
    /// <summary>
    /// Defines the IRBP-L300-L4000 external rotational axis
    /// </summary>
    public static class EDEK_IRBP_L300_L4000
    {
        /// <summary>
        /// Defines the IRBP-L300-L4000 external rotational axis
        /// </summary>
        /// <param name="name"> The name of the external rotational axis. </param>
        /// <param name="positionPlane"> The position of the axis plane in world coordinate space as plane. </param>
        /// <param name="axisLimit"> The axis limits as a domain. </param>
        /// <param name="additionalLinkMesh"> Additional mesh for link as a single mesh. </param>
        /// <returns> Returns the external rotational axis preset. </returns>
        public static ExternalRotationalAxis GetExternalRotationalAxis(string name, Plane positionPlane, Interval axisLimit, Mesh additionalBaseMesh = null, Mesh additionalLinkMesh = null)
        {
            List<Mesh> meshes = GetMeshes();
            Plane axisPlane = Plane.WorldXY;

            if (additionalBaseMesh != null)
            {
                meshes[0].Append(additionalBaseMesh);
            }

            if (additionalLinkMesh != null)
            {
                meshes[1].Append(additionalLinkMesh);
            }

            ExternalRotationalAxis externalRotationalAxis = new ExternalRotationalAxis(name, axisPlane, axisLimit, meshes[0], meshes[1]);
            Transform trans = Transform.PlaneToPlane(Plane.WorldXY, positionPlane);
            externalRotationalAxis.Transform(trans);

            return externalRotationalAxis;
        }

        /// <summary>
        /// Defines the IRBP-L300-L4000 external rotational axis
        /// </summary>
        /// <param name="name"> The name of the external rotational axis. </param>
        /// <param name="positionPlane"> The position of the axis plane in world coordinate space as plane. </param>
        /// <param name="axisLimit"> The axis limits as a domain. </param>
        /// <param name="additionalBaseMeshes"> Additional mesh for base as a list with meshes. </param>
        /// <param name="additionalLinkMeshes"> Additional mesh for link as a list with meshes. </param>
        /// <returns> Returns the external rotational axis preset. </returns>
        public static ExternalRotationalAxis GetExternalRotationalAxis(string name, Plane positionPlane, Interval axisLimit = new Interval(), List<Mesh> additionalBaseMeshes = null, List < Mesh> additionalLinkMeshes = null)
        {
            Mesh additionalBaseMesh = new Mesh();
            Mesh additionalLinkMesh = new Mesh();

            if (additionalBaseMeshes != null)
            {
                for (int i = 0; i < additionalBaseMeshes.Count; i++)
                {
                    additionalBaseMesh.Append(additionalBaseMeshes[i]);
                }
            }

            if (additionalLinkMeshes != null)
            {
                for (int i = 0; i < additionalLinkMeshes.Count; i++)
                {
                    additionalLinkMesh.Append(additionalLinkMeshes[i]);
                }
            }

            ExternalRotationalAxis externalRotationalAxis = GetExternalRotationalAxis(name, positionPlane, axisLimit, additionalBaseMesh, additionalLinkMesh);
            return externalRotationalAxis;
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
            linkString = RobotComponentsEDEK.Properties.Resources.IRBP_L300_L4000_link_0;
            meshes.Add((Mesh)HelperMethods.ByteArrayToObject(System.Convert.FromBase64String(linkString)));
            // Axis 1
            linkString = RobotComponentsEDEK.Properties.Resources.IRBP_L300_L4000_link_1;
            meshes.Add((Mesh)HelperMethods.ByteArrayToObject(System.Convert.FromBase64String(linkString)));

            return meshes;
        }

    }
}
