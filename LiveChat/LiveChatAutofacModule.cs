using Autofac;


namespace LiveChat.Data
{
    public class LiveChatAutofacModule : Module
    {
        public static LiveChatAutofacModule Create => new LiveChatAutofacModule();

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(LiveChatDataAutofacModule.Create);
            builder.RegisterModule(LiveChatDomainAutofacModule.Create);

            base.Load(builder);
        }
    }
}
