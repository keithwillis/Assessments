using System;
namespace Assessment
{
    public class BronzeMember : MemberBase
    {
        public BronzeMember()
        {
            Cart = new Cart(Discount);
        }

        public override decimal Discount
        {
            get { return 0M; }
        }
    }
}
