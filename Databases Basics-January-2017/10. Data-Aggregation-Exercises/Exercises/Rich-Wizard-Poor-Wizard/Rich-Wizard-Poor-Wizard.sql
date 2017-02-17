USE Gringotts

SELECT SUM(hostWizardAmount - guestWizardAmount) AS [SumDifference] FROM
	(
		SELECT 
			DepositAmount AS [hostWizardAmount],
			LEAD(DepositAmount) OVER (ORDER BY Id) AS [guestWizardAmount]
		 FROM WizzardDeposits
	) AS a