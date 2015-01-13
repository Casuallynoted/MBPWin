' The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkID=391641

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page

    Dim AmountText As String
    Dim Amount As Double
    Dim AmountEntered As Double
    Dim AccountBalance As Double

    ''' <summary>
    ''' Invoked when this page is about to be displayed in a Frame.
    ''' </summary>
    ''' <param name="e">Event data that describes how this page was reached.
    ''' This parameter is typically used to configure the page.</param>
    Protected Overrides Sub OnNavigatedTo(e As Navigation.NavigationEventArgs)
        ' TODO: Prepare the page for display here. 
        ' TODO: If your application contains multiple pages, ensure that you are
        ' handling the hardware Back button by registering for the
        ' Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
        ' If you are using the NavigationHelper provided by some templates,
        ' this event is handled for you.
    End Sub




    Private Sub Deposit_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) Handles Deposit.Click
        If TextInput.Text = Nothing Then
            AmountText = "0"
        Else
            AmountText = TextInput.Text
        End If
        Amount = Convert.ToDecimal(AmountText)
        AmountEntered = Amount
        AccountBalance = AccountBalance + AmountEntered
        TextInput.Text = ""
        BalanceTeller.Text = "Your account balance is " + AccountBalance.ToString

    End Sub

    Private Sub Withdraw_Click(sender As Object, e As RoutedEventArgs) Handles Withdraw.Click
        If TextInput.Text = Nothing Then
            AmountText = "0"
        Else
            AmountText = TextInput.Text
        End If
        Amount = Convert.ToDecimal(AmountText)
        AmountEntered = Amount
        If (AccountBalance - AmountEntered) < 0 Then
            FlyoutBase.ShowAttachedFlyout(LayoutRoot)
        Else
            AccountBalance = AccountBalance - AmountEntered
            TextInput.Text = ""
            BalanceTeller.Text = "Your account balance is " + AccountBalance.ToString

        End If

    End Sub

    Private Sub About_Click(sender As Object, e As RoutedEventArgs) Handles About.Click
        Me.Frame.Navigate(GetType(AboutPage))
    End Sub

    Private Sub Confirmation_Click(sender As Object, e As RoutedEventArgs) Handles Confirmation.Click

        AccountBalance = AccountBalance - AmountEntered - 30
        BalanceTeller.Text = "Your account balance is " + AccountBalance.ToString + ", heathen."
        TextInput.Text = ""
        FlyGuy.Hide()
    End Sub

    Private Sub Cancellation_Click(sender As Object, e As RoutedEventArgs) Handles Cancellation.Click

        TextInput.Text = ""
        FlyGuy.Hide()
    End Sub
End Class
