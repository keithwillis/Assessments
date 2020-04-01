using System;
namespace Assessment
{
    public class GoldMember : MemberBase
    {
        public GoldMember()
        {
            Cart = new Cart(Discount);
        }

        public override decimal Discount
        {
            get { return .15M; }
        }

    }
}
