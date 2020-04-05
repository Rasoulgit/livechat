using Autofac;
using LiveChat.Domain.Chat.Concrete;

namespace LiveChat.Data
{
    public class LiveChatDomainAutofacModule : Module
    {
        public static LiveChatDomainAutofacModule Create => new LiveChatDomainAutofacModule();

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<RoomService>().AsImplementedInterfaces();
            builder.RegisterType<ChatService>().AsImplementedInterfaces();
            builder.RegisterType<UserValidator>().AsImplementedInterfaces();

            base.Load(builder);
        }
    }
}
