using System;

namespace Lab3
{
    // We renamed these enumerators to make them more clear.
	public enum Class
	{
		FirstClass,
		SecondClass
	}

	public enum Way
	{
		OneWay,
		Return
	}

	public enum Discount
	{
		NoDiscount,
		TwentyDiscount,
		FortyDiscount
	}

	public enum Payment
	{
		DebitCard,
		CreditCard,
		Cash
	}

	public struct Ticket
	{
		string from, to;
		Class firstOrSecondClass;
		Way way;
		Discount discount;
		Payment payment;

		public Ticket (string from, string to, Class cls, Way way, Discount discount, Payment payment)
		{
			this.from = from;
			this.to = to;
			this.firstOrSecondClass = cls;
			this.way = way;
			this.discount = discount;
			this.payment = payment;
		}

		public string From {
			get {
				return from;
			}
		}

		public string To {
			get {
				return to;
			}
		}

		public Class Class {
			get {
				return firstOrSecondClass;
			}
		}

		public Way Way {
			get {
				return way;
			}
		}

		public Discount Discount {
			get {
				return discount;
			}
		}

		public Payment Payment {
			get {
				return payment;
			}
		}
	}
}

