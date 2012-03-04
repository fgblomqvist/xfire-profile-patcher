Imports System.Drawing
Imports System.Windows.Forms

Namespace WinFormsControls
    ''' <summary>
    ''' A label that can be transparent.
    ''' </summary>
    Public Class TransparentLabel
        Inherits Control
        ''' <summary>
        ''' Creates a new <see cref="TransparentLabel"/> instance.
        ''' </summary>
        Public Sub New()
            TabStop = False
        End Sub

        ''' <summary>
        ''' Gets the creation parameters.
        ''' </summary>
        Protected Overrides ReadOnly Property CreateParams() As CreateParams
            Get
                Dim cp As CreateParams = MyBase.CreateParams
                cp.ExStyle = cp.ExStyle Or &H20
                Return cp
            End Get
        End Property

        ''' <summary>
        ''' Paints the background.
        ''' </summary>
        ''' <param name="e">E.</param>
        Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
            ' do nothing
        End Sub

        ''' <summary>
        ''' Paints the control.
        ''' </summary>
        ''' <param name="e">E.</param>
        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            DrawText()
        End Sub

        Protected Overrides Sub WndProc(ByRef m As Message)
            MyBase.WndProc(m)
            If m.Msg = &HF Then
                DrawText()
            End If
        End Sub

        Private Sub DrawText()
            Using graphics As Graphics = CreateGraphics()
                Using brush As New SolidBrush(ForeColor)
                    Dim size As SizeF = graphics.MeasureString(Text, Font)

                    ' first figure out the top
                    Dim top As Single = 0
                    Select Case m_textAlign
                        Case ContentAlignment.MiddleLeft, ContentAlignment.MiddleCenter, ContentAlignment.MiddleRight
                            top = (Height - size.Height) / 2
                            Exit Select
                        Case ContentAlignment.BottomLeft, ContentAlignment.BottomCenter, ContentAlignment.BottomRight
                            top = Height - size.Height
                            Exit Select
                    End Select

                    Dim left As Single = -1
                    Select Case m_textAlign
                        Case ContentAlignment.TopLeft, ContentAlignment.MiddleLeft, ContentAlignment.BottomLeft
                            If RightToLeft = RightToLeft.Yes Then
                                left = Width - size.Width
                            Else
                                left = -1
                            End If
                            Exit Select
                        Case ContentAlignment.TopCenter, ContentAlignment.MiddleCenter, ContentAlignment.BottomCenter
                            left = (Width - size.Width) / 2
                            Exit Select
                        Case ContentAlignment.TopRight, ContentAlignment.MiddleRight, ContentAlignment.BottomRight
                            If RightToLeft = RightToLeft.Yes Then
                                left = -1
                            Else
                                left = Width - size.Width
                            End If
                            Exit Select
                    End Select
                    graphics.DrawString(Text, Font, brush, left, top)
                End Using
            End Using
        End Sub

        ''' <summary>
        ''' Gets or sets the text associated with this control.
        ''' </summary>
        ''' <returns>
        ''' The text associated with this control.
        ''' </returns>
        Public Overrides Property Text() As String
            Get
                Return MyBase.Text
            End Get
            Set(value As String)
                MyBase.Text = value
                RecreateHandle()
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a value indicating whether control's elements are aligned to support locales using right-to-left fonts.
        ''' </summary>
        ''' <value></value>
        ''' <returns>
        ''' One of the <see cref="T:System.Windows.Forms.RightToLeft"/> values. The default is <see cref="F:System.Windows.Forms.RightToLeft.Inherit"/>.
        ''' </returns>
        ''' <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">
        ''' The assigned value is not one of the <see cref="T:System.Windows.Forms.RightToLeft"/> values.
        ''' </exception>
        Public Overrides Property RightToLeft() As RightToLeft
            Get
                Return MyBase.RightToLeft
            End Get
            Set(value As RightToLeft)
                MyBase.RightToLeft = value
                RecreateHandle()
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the font of the text displayed by the control.
        ''' </summary>
        ''' <value></value>
        ''' <returns>
        ''' The <see cref="T:System.Drawing.Font"/> to apply to the text displayed by the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultFont"/> property.
        ''' </returns>
        Public Overrides Property Font() As Font
            Get
                Return MyBase.Font
            End Get
            Set(value As Font)
                MyBase.Font = value
                RecreateHandle()
            End Set
        End Property

        Private m_textAlign As ContentAlignment = ContentAlignment.TopLeft
        ''' <summary>
        ''' Gets or sets the text alignment.
        ''' </summary>
        Public Property TextAlign() As ContentAlignment
            Get
                Return m_textAlign
            End Get
            Set(value As ContentAlignment)
                m_textAlign = value
                RecreateHandle()
            End Set
        End Property
    End Class
End Namespace
