
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdapterPattern{
    public class Client {

        public Client() {
        }
        /// <summary>
        /// ������ģʽ������ͨ�õķ��������Ŀ�����
        /// ������ģʽ(Adapter Pattern) ����һ���ӿ�ת���ɿͻ�ϣ������һ���ӿڣ�
        /// ������ģʽʹ�ӿڲ����ݵ���Щ�����һ�����������Ϊ��װ��(Wrapper)��
        /// ������ģʽ�ȿ�����Ϊ��ṹ��ģʽ��Ҳ������Ϊ����ṹ��ģʽ��
        /// 
        /// ʹ��һ���Ѿ����ڵ��࣬��������Ľӿڣ�Ҳ�������ķ�������Ҫ��Ĳ���ͬʱ����Ӧ��ʹ��������ģʽ��
        /// ������������������ͬ�����ƣ����Ǿ��в�ͬ�Ľӿ�
        /// </summary>
        public void Test() {
            Target target = new Adapter();
            target.Request();
        }

    }
}