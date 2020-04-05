using Autofac;
using LiveChat.Data.Repositories.Concrete;

namespace LiveChat.Data
{
    public class LiveChatDataAutofacModule : Module
    {
        public static LiveChatDataAutofacModule Create => new LiveChatDataAutofacModule();

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LiveChatContext>().SingleInstance();

            builder.RegisterType<RoomRepository>().AsImplementedInterfaces();
            builder.RegisterType<DataUnitOfWork>().AsImplementedInterfaces();

            base.Load(builder);
        }
    }
}
