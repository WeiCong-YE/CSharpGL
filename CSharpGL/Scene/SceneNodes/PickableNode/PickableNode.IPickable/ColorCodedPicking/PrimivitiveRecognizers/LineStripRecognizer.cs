﻿using System;
using System.Collections.Generic;

namespace CSharpGL
{
    internal class LineStripRecognizer : PrimitiveRecognizer
    {
        protected override void RecognizeUInt(uint flatColorVertexId, DrawElementsCmd cmd, List<RecognizedPrimitiveInfo> primitiveInfoList)
        {
            IndexBuffer indexBuffer = cmd.IndexBufferObject;
            int length = indexBuffer.Length;
            IntPtr pointer = indexBuffer.MapBuffer(MapBufferAccess.ReadOnly);
            unsafe
            {
                var array = (uint*)pointer.ToPointer();
                uint i = 0;
                for (i = i + 1; i < length; i++)
                {
                    var value = array[i];
                    if (value == flatColorVertexId)
                    {
                        var item = new RecognizedPrimitiveInfo(i, array[i - 1], flatColorVertexId);
                        primitiveInfoList.Add(item);
                    }
                }
            }
            indexBuffer.UnmapBuffer();
        }

        protected override void RecognizeUShort(uint flatColorVertexId, DrawElementsCmd cmd, List<RecognizedPrimitiveInfo> primitiveInfoList)
        {
            IndexBuffer indexBuffer = cmd.IndexBufferObject;
            int length = indexBuffer.Length;
            IntPtr pointer = indexBuffer.MapBuffer(MapBufferAccess.ReadOnly);
            unsafe
            {
                var array = (ushort*)pointer.ToPointer();
                uint i = 0;
                for (i = i + 1; i < length; i++)
                {
                    var value = array[i];
                    if (value == flatColorVertexId)
                    {
                        var item = new RecognizedPrimitiveInfo(i, array[i - 1], flatColorVertexId);
                        primitiveInfoList.Add(item);
                    }
                }
            }
            indexBuffer.UnmapBuffer();
        }

        protected override void RecognizeByte(uint flatColorVertexId, DrawElementsCmd cmd, List<RecognizedPrimitiveInfo> primitiveInfoList)
        {
            IndexBuffer indexBuffer = cmd.IndexBufferObject;
            int length = indexBuffer.Length;
            IntPtr pointer = indexBuffer.MapBuffer(MapBufferAccess.ReadOnly);
            unsafe
            {
                var array = (byte*)pointer.ToPointer();
                uint i = 0;
                for (i = i + 1; i < length; i++)
                {
                    var value = array[i];
                    if (value == flatColorVertexId)
                    {
                        var item = new RecognizedPrimitiveInfo(i, array[i - 1], flatColorVertexId);
                        primitiveInfoList.Add(item);
                    }
                }
            }
            indexBuffer.UnmapBuffer();
        }

        protected override void RecognizeUInt(uint flatColorVertexId, DrawElementsCmd cmd, List<RecognizedPrimitiveInfo> primitiveInfoList, uint primitiveRestartIndex)
        {
            IndexBuffer indexBuffer = cmd.IndexBufferObject;
            int length = indexBuffer.Length;
            IntPtr pointer = indexBuffer.MapBuffer(MapBufferAccess.ReadOnly);
            unsafe
            {
                var array = (uint*)pointer.ToPointer();
                long nearestRestartIndex = -1;
                uint i = 0;
                while (i < length && array[i] == primitiveRestartIndex)
                { nearestRestartIndex = i; i++; }
                for (i = i + 1; i < length; i++)
                {
                    var value = array[i];
                    if (value == primitiveRestartIndex)
                    {
                        // try the loop back line.
                        nearestRestartIndex = i;
                    }
                    else if (value == flatColorVertexId
                        && array[i - 1] != primitiveRestartIndex)
                    {
                        var item = new RecognizedPrimitiveInfo(i, array[i - 1], flatColorVertexId);
                        primitiveInfoList.Add(item);
                    }
                }
            }
            indexBuffer.UnmapBuffer();
        }

        protected override void RecognizeUShort(uint flatColorVertexId, DrawElementsCmd cmd, List<RecognizedPrimitiveInfo> primitiveInfoList, uint primitiveRestartIndex)
        {
            IndexBuffer indexBuffer = cmd.IndexBufferObject;
            int length = indexBuffer.Length;
            IntPtr pointer = indexBuffer.MapBuffer(MapBufferAccess.ReadOnly);
            unsafe
            {
                var array = (ushort*)pointer.ToPointer();
                long nearestRestartIndex = -1;
                uint i = 0;
                while (i < length && array[i] == primitiveRestartIndex)
                { nearestRestartIndex = i; i++; }
                for (i = i + 1; i < length; i++)
                {
                    var value = array[i];
                    if (value == primitiveRestartIndex)
                    {
                        // try the loop back line.
                        nearestRestartIndex = i;
                    }
                    else if (value == flatColorVertexId
                        && array[i - 1] != primitiveRestartIndex)
                    {
                        var item = new RecognizedPrimitiveInfo(i, array[i - 1], flatColorVertexId);
                        primitiveInfoList.Add(item);
                    }
                }
            }
            indexBuffer.UnmapBuffer();
        }

        protected override void RecognizeByte(uint flatColorVertexId, DrawElementsCmd cmd, List<RecognizedPrimitiveInfo> primitiveInfoList, uint primitiveRestartIndex)
        {
            IndexBuffer indexBuffer = cmd.IndexBufferObject;
            int length = indexBuffer.Length;
            IntPtr pointer = indexBuffer.MapBuffer(MapBufferAccess.ReadOnly);
            unsafe
            {
                var array = (byte*)pointer.ToPointer();
                long nearestRestartIndex = -1;
                uint i = 0;
                while (i < length && array[i] == primitiveRestartIndex)
                { nearestRestartIndex = i; i++; }
                for (i = i + 1; i < length; i++)
                {
                    var value = array[i];
                    if (value == primitiveRestartIndex)
                    {
                        // try the loop back line.
                        nearestRestartIndex = i;
                    }
                    else if (value == flatColorVertexId
                        && array[i - 1] != primitiveRestartIndex)
                    {
                        var item = new RecognizedPrimitiveInfo(i, array[i - 1], flatColorVertexId);
                        primitiveInfoList.Add(item);
                    }
                }
            }
            indexBuffer.UnmapBuffer();
        }
    }
}