
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorPattern.Model
{
    public class Client
    {

        public Client()
        {
        }

        /// <summary>
        /// װ��ģʽ������SetComponent���Զ�����з�װ������ÿ��װ�ζ����ʵ�־ͺ����ʹ�����������뿪�ˣ�
        /// ÿ��װ�ζ���ֻ�����Լ��Ĺ��ܣ�����Ҫ������α���ӵ���������
        /// �����
        /// ����������
        /// ����װ�ζ���A�Ĳ���
        /// ����װ�ζ���B�Ĳ���
        /// </summary>
        public void Test()
        {
            ConcreteComponent c = new ConcreteComponent();
            ConcreteDecoratorA a = new ConcreteDecoratorA();
            ConcreteDecoratorB b = new ConcreteDecoratorB();
            a.SetComponent(c);
            b.SetComponent(a);
            b.Operation();

        }

    }
}