
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace BrigdePattern.Model
{
    public class Client
    {

        public Client()
        {
        }

        /// <summary>
        /// �Ž�ģʽ(Bridge Pattern)�������󲿷�������ʵ�ֲ��ַ��룬ʹ���Ƕ����Զ����ر仯������һ�ֶ���ṹ��ģʽ��
        /// �ֳ�Ϊ����(Handle and Body)ģʽ��ӿ�(Interface)ģʽ��
        /// 
        /// �Ž�ģʽ���̳й�ϵת��Ϊ������ϵ���Ӷ�������������֮�����ϣ������˴����д����
        /// 
        /// Abstraction��������
        /// RefinedAbstraction�����������
        /// Implementor��ʵ����ӿ�
        /// ConcreteImplementor������ʵ����
        /// </summary>
        public void Test()
        {
            Abstraction a = new RefinedAbstraction(new ConcreteImplementorA());
            a.Operation();
            Abstraction b = new RefinedAbstraction(new ConcreteImplementorB());
            b.Operation();
        }

    }
}