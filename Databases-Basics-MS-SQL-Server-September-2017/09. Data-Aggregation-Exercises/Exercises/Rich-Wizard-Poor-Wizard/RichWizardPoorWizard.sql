SELECT SUM(HostWizardAmount - GuestWizardAmount) AS [SumDifference] FROM
(
	SELECT 
		DepositAmount AS [HostWizardAmount],
		LEAD(DepositAmount) OVER (ORDER BY Id) AS [GuestWizardAmount]
		FROM WizzardDeposits
) AS sq