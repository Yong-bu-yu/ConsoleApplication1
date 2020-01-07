#include"pch.h"
#include <stdio.h>
#include <conio.h>
#include <iostream>

using namespace std;
class person
{
	friend class list;
protected:
	char name[20];
	int age;
	char add[40];
	char tele[15];
	static person *ptr;
	person *next;
public:
	person(char *, int, char *, char *);
	virtual void print() ;
	virtual void insert() = 0;
};
class student :public person
{
	friend class list;
	int level;
	float grade_point_average;
public:
	student(char *, int, char *, char *, int, float);
	void print();
	void insert();
};
class teacher :public person
{
	friend class list;
	float salary;
public:
	teacher(char *, int, char *, char *, float);
	void print();
	void insert();
};
class staff :public person
{
	friend class list; 
	float hourly_wages;
public:
	staff(char *, int, char *, char *, float);
	void print();
	void insert();
};
class list
{
	person *root;
public:
	list() { root = 0; }
	void insert_person(person *node);
	void remove(char *name);
	void print_list();
};
person::person(char *name, int age, char *add, char *tele)
{
	strcpy_s(person::name, name);
	strcpy_s(person::add, add);
	strcpy_s(person::tele, tele);
	person::age = age;
	next = 0;
}
void person::print()
{
	cout << "\nname:" << name << "\n";
	cout << "age:" << age << "\n";
	cout << "address:" << add << "\n";
	cout << "telephone number:" << tele << "\n";
}
student::student(char *name, int age, char *add, char *tele, int level, float grade_point_average) :person(name, age, add, tele)
{
	student::level = level;
	student::grade_point_average = grade_point_average;
}
void student::print()
{
	person::print();
	cout << "grade point average:" << grade_point_average << "\n";
}
void student::insert()
{
	ptr = new student(name, age, add, tele, level, grade_point_average);
}
teacher::teacher(char *name, int age, char *add, char *tele, float salary) :person(name, age, add, tele)
{
	teacher::salary = salary;
}
void teacher::insert()
{
	ptr = new teacher(name, age, add, tele, salary);
}
void teacher::print()
{
	person::print();
	cout << "salary:" << salary << "\n";
}
staff::staff(char *name, int age, char *add, char *tele, float hourly_wages) : person(name, age, add, tele)
{
	staff::hourly_wages = hourly_wages;
}
void staff::insert()
{
	ptr = new staff(name, age, add, tele, hourly_wages);
}
void staff::print()
{
	person::print();
	cout << "hourly_wages:" << hourly_wages << "\n";
}
void list::insert_person(person *node)
{
	char key[20];
	strcpy_s(key, node->name);
	person *curr_node = root;
	person *previous = 0;
	while (curr_node != 0 && strcmp(curr_node->name, key) < 0)
	{
		previous = curr_node;
		curr_node = curr_node->next;
	}
	node->insert();
	node->ptr->next = curr_node;
	if (previous == 0)
		root = node->ptr;
	else
		previous->next = node->ptr;
}
void list::remove(char *name)
{
	person *curr_node = root;
	person *previous = 0;
	while (curr_node != 0 && strcmp(curr_node->name, name) != 0)
	{
		previous = curr_node;
		curr_node = curr_node->next;
	}
	if (curr_node!=0&&previous==0)
	{
		root = curr_node->next;
		delete curr_node;
	}
	else if (curr_node != 0 && previous != 0)
	{
		previous->next = curr_node->next;
		delete curr_node;
	}
}
void list::print_list()
{
	person *cur = root;
	while (cur!=0)
	{
		cur->print();
		cur = cur->next;
	}
}
person *person::ptr = 0;
int main()
{
	char c;
	list people;
	char stu_name[20] = "刘影liuying", stu_add[40] = "上海shanghai", stu_tele[15] = "03578395-456";
	char tea_name[20] = "李明liming", tea_add[40] = "北京beijing", tea_tele[15] = "0105918695-106";
	char sta_name[20] = "陈林chenling", sta_add[40] = "青岛qingdao", sta_tele[15] = "0532589594-335";
	student stu(stu_name, 20,stu_add ,stu_tele , 3, 80.0);

	teacher tea(tea_name, 35,tea_add ,tea_tele , 560.50);
	staff   sta(sta_name, 40,sta_add ,sta_tele , 10);
	people.insert_person(&stu);
	people.insert_person(&tea);
	people.insert_person(&sta);
	cout << "插入结束!\n";
	people.print_list();
	cout << "\n以上打印出原链表!\n";
	cin >> c;
	people.remove(stu_name);
	people.remove(tea_name);
	people.remove(sta_name);
	cout << "删除结束!\n";
	people.print_list();
	cout << "\n以上打印出删除后链表!\n";
	return 0;
}

