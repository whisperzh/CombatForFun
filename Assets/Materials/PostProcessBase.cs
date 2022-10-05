﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class PostProcessBase : MonoBehaviour
{
    
    protected void Start()
    {
        CheckResources();
    }

    protected void CheckResources()
    {
        bool isSupported = CheckSupport();

        if(!isSupported)
        {
            NotSupported();
        }
    }

    protected bool CheckSupport()
    {
        return true;
    }

    protected void NotSupported()
    {
        enabled = false;
    }

    protected Material CheckShaderAndCreateMatrerial(Shader shader,Material material)
    {
        if (shader == null)
            return null;


        if (shader.isSupported && material && material.shader == shader)
        {
            return material;
        }

        if (!shader.isSupported)
            return null;
        else
        {
            material = new Material(shader);
            material.hideFlags = HideFlags.DontSave;
            if (material)
                return material;
            else
                return null;
        }
    }

}
