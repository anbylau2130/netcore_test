
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BuilderPattern.Builders;
using BuilderPattern.Model;

namespace BuilderPattern
{
    public class KFCWaiter
    {

        private MealBuilder mealBuilder;

        public  KFCWaiter(MealBuilder mealBuilder)
        {
            this.mealBuilder = mealBuilder;
        }


        /// <summary>
        /// ����ģʽ(Builder Pattern)����һ�����Ӷ���Ĺ��������ı�ʾ���룬
        /// ʹ��ͬ���Ĺ������̿��Դ�����ͬ�ı�ʾ��
        /// ������ģʽ��һ��һ������һ�����ӵĶ���
        /// �������û�ֻͨ��ָ�����Ӷ�������ͺ����ݾͿ��Թ������ǣ�
        /// �û�����Ҫ֪���ڲ��ľ��幹��ϸ�ڡ�������ģʽ���ڶ��󴴽���ģʽ��
        /// �������ķ���Ĳ�ͬ��������ģʽ�ֿ��Գ�Ϊ������ģʽ��
        /// </summary>
        public Meal BuildMeal()
        {
            var meal = this.mealBuilder.GetMeal();
            return meal;
        }

    }
}