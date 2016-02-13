****************************************************************************

Алгоритм размещения службы в IIS.

****************************************************************************

Создать папку ServiceIIS

В папке ServiceIIS - Создать папку ProjectIIS

В папке ProjectIIS создать папку bin

В папке ProjectIIS создать файл MyService.svc

Запустить MS Visual Studio. Перейти: File - Open - WebSite 
В диалоге выбора проекта, в качестве папки Web-проекта указать созданную папку - ProjectIIS. (ОК!)

----------------------------------------------------------------------------

В результате откроется проект, и в Solution Explorer отобразятся:

- папка bin
- файл MyService.svc
- и файл Web.config, который студия сгенерировала автоматически при открытии проекта.


Сохранить проект Ctrl+S - студия предложит выбрать путь для сохранения файла решения ProjectIIS.sln
В качестве папки хранения выбрать папку - ServiceIIS.

----------------------------------------------------------------------------

Открыть MyService.svc и записать в него строку:
<%@ServiceHost Language=c# Service="ServiceLibrary.MyService" %>

И ниже в файле MyService.svc написать конракт и реализацию службы:

using System;
using System.ServiceModel;

namespace ServiceLibrary
{
    [ServiceContract]
    interface IContract
    {
        [OperationContract]
        string Method(string s);
    }
    
    public class MyService : IContract
    {
        public string Method(string s)
        {
            return s + " IIS";
        }
    }
}


----------------------------------------------------------------------------

Открыть Web.config и добавить в него секцию <system.serviceModel> 
после секции </configSections>:

<system.serviceModel>
    <services>
      <service name="ServiceLibrary.MyService" behaviorConfiguration="MEXServiceTypeBehavior">
        <endpoint address="" binding="basicHttpBinding" contract="ServiceLibrary.IContract"/>
        <endpoint address="mex" binding="mexHttpBinding" contract="IMetadataExchange"/>
      </service>
    </services>
    <behaviors>
      <serviceBehaviors>
        <behavior name="MEXServiceTypeBehavior">
          <serviceMetadata httpGetEnabled="true"/>
        </behavior>
      </serviceBehaviors>
    </behaviors>
  </system.serviceModel>

-----------------------------------------------------------------------------

Запустить Диспетчер служб IIS.

Добавить Виртуальный каталог, присвоить ему имя, например, My, 
в пути выбора указать папку с проектом сервиса - ProjectIIS

Преобразовать виртуальный каталог в приложение 
(правой кнопкой по каталогу и выбрать команду - преобразовать в приложение.)

-----------------------------------------------------------------------------

ПРОВЕРКА: 

Открыть Web-браузер IE, в строке адреса указать путь к сервису (Enter)
Например: http://localhost/My/MyService.svc

Должна отобразиться страница описания сервиса.

-----------------------------------------------------------------------------


Создать клиент, и обратиться с запросом к созданному сервису.


-----------------------------------------------------------------------------





