﻿'Copyright (C) 2016 Guillermo Hazebrouck

Imports SharpGL
Imports MathTools.Algebra.EuclideanSpace

Namespace VisualModel.Environment.Frames

    Public Class ReferenceFrame

        Public ColorDelWireFrame As System.Drawing.Color = Drawing.Color.LightGray
        Public Xmax As Double = 5
        Public Ymax As Double = 5
        Public Xmin As Double = -5
        Public Ymin As Double = -5
        Public Z As Double = 0
        Public ConMarcacionFina As Boolean = True
        Public ConMarcacionGruesa As Boolean = True

        Public Sub CreateWireFrame(ByRef gl As OpenGL)

            gl.LineWidth(1.0F)
            gl.Begin(OpenGL.GL_LINES)

            gl.Color(ColorDelWireFrame.R / 255, ColorDelWireFrame.G / 255, ColorDelWireFrame.B / 255)

            gl.Vertex(Xmin, Ymin, Z)
            gl.Vertex(Xmax, Ymin, Z)

            gl.Vertex(Xmax, Ymin, Z)
            gl.Vertex(Xmax, Ymax, Z)

            gl.Vertex(Xmax, Ymax, Z)
            gl.Vertex(Xmin, Ymax, Z)

            gl.Vertex(Xmin, Ymax, Z)
            gl.Vertex(Xmin, Ymin, Z)

            Dim Punto As New EVector3
            Dim Xm As Double = 0.0
            Dim Ym As Double = 0.0
            Dim Zm As Double = 0.0
            Dim i As Integer = 0

            gl.End()

            If ConMarcacionGruesa Then

                gl.LineWidth(1.0F)
                gl.Begin(OpenGL.GL_LINES)

                ' Marcacion gruesa en direccion X:

                Punto.Z = 0.0#
                Do While Xm < Xmax
                    gl.Vertex(Xm, -0.085, Z)
                    gl.Vertex(Xm, 0.085, Z)
                    Xm = Xm + 1
                Loop

                Xm = -1
                Do While Xm > Xmin
                    gl.Vertex(Xm, -0.085, Z)
                    gl.Vertex(Xm, 0.085, Z)
                    Xm = Xm - 1
                Loop

                ' Marcacion gruesa en direccion Y:

                Ym = 0
                Do While Ym < Ymax
                    gl.Vertex(0.085, Ym, Z)
                    gl.Vertex(-0.085, Ym, Z)
                    Ym = Ym + 1
                Loop

                Ym = -1
                Do While Ym > Ymin
                    gl.Vertex(0.085, Ym, Z)
                    gl.Vertex(-0.085, Ym, Z)
                    Ym = Ym - 1
                Loop

                gl.End()

            End If

            If ConMarcacionFina Then

                gl.LineWidth(0.5F)

                gl.Begin(OpenGL.GL_LINES)

                ' Marcacion fina en direccion X:

                i = 0
                Xm = 0.2
                Do While Xm < Xmax And Xm <> i
                    gl.Vertex(Xm, -0.05, Z)
                    gl.Vertex(Xm, 0.085, Z)
                    Xm = Xm + 0.2
                Loop

                i = 0
                Xm = -0.2
                Do While Xm > Xmin And Xm <> i
                    gl.Vertex(Xm, -0.05, Z)
                    gl.Vertex(Xm, 0.05, Z)
                    Xm = Xm - 0.2
                    i = i - 1
                Loop

                ' Marcacion fina en direccion Y:

                i = 0
                Ym = 0.2
                Do While Ym < Ymax And Ym <> i
                    gl.Vertex(0.05, Ym, Z)
                    gl.Vertex(-0.05, Ym, Z)
                    Ym = Ym + 0.2
                Loop

                i = 0
                Ym = -0.2
                Do While Ym > Ymin And Ym <> i
                    gl.Vertex(0.05, Ym, Z)
                    gl.Vertex(-0.05, Ym, Z)
                    Ym = Ym - 0.2
                    i = i - 1
                Loop

                gl.End()

            End If

        End Sub

    End Class

    Public Class CoordinateAxes

        Public Extension As Double = 1.0F

        Public Sub CrearWireFrame(ByRef gl As OpenGL)

            gl.LineWidth(2.0F)
            gl.Begin(OpenGL.GL_LINES)

            gl.Color(0.0F, 1.0F, 0.0F)
            gl.Vertex(0.0F, 0.0F, 0.0F)
            gl.Vertex(Extension, 0.0F, 0.0F)

            gl.Color(1.0F, 0.0F, 0.0F)
            gl.Vertex(0.0F, 0.0F, 0.0F)
            gl.Vertex(0.0F, Extension, 0.0F)

            gl.Color(0.4F, 0.0F, 0.8F)
            gl.Vertex(0.0F, 0.0F, 0.0F)
            gl.Vertex(0.0F, 0.0F, Extension)

            gl.End()

        End Sub

    End Class

End Namespace