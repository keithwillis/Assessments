using System;
namespace Assessment
{
    public class SilverMember: MemberBase
    {
        public SilverMember()
        {
            Cart = new Cart(Discount);
        }

        public override decimal Discount
        {
            get { return .10M; }
        }

    }
}
