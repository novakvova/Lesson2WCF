****************************************************************************

�������� ���������� ������ � IIS.

****************************************************************************

������� ����� ServiceIIS

� ����� ServiceIIS - ������� ����� ProjectIIS

� ����� ProjectIIS ������� ����� bin

� ����� ProjectIIS ������� ���� MyService.svc

��������� MS Visual Studio. �������: File - Open - WebSite 
� ������� ������ �������, � �������� ����� Web-������� ������� ��������� ����� - ProjectIIS. (��!)

----------------------------------------------------------------------------

� ���������� ��������� ������, � � Solution Explorer �����������:

- ����� bin
- ���� MyService.svc
- � ���� Web.config, ������� ������ ������������� ������������� ��� �������� �������.


��������� ������ Ctrl+S - ������ ��������� ������� ���� ��� ���������� ����� ������� ProjectIIS.sln
� �������� ����� �������� ������� ����� - ServiceIIS.

----------------------------------------------------------------------------

������� MyService.svc � �������� � ���� ������:
<%@ServiceHost Language=c# Service="ServiceLibrary.MyService" %>

� ���� � ����� MyService.svc �������� ������� � ���������� ������:

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

������� Web.config � �������� � ���� ������ <system.serviceModel> 
����� ������ </configSections>:

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

��������� ��������� ����� IIS.

�������� ����������� �������, ��������� ��� ���, ��������, My, 
� ���� ������ ������� ����� � �������� ������� - ProjectIIS

������������� ����������� ������� � ���������� 
(������ ������� �� �������� � ������� ������� - ������������� � ����������.)

-----------------------------------------------------------------------------

��������: 

������� Web-������� IE, � ������ ������ ������� ���� � ������� (Enter)
��������: http://localhost/My/MyService.svc

������ ������������ �������� �������� �������.

-----------------------------------------------------------------------------


������� ������, � ���������� � �������� � ���������� �������.


-----------------------------------------------------------------------------





