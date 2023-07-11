using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Book
{
    public string ID;
    public string Author;
    public string Title;
    public string Genre;
    public decimal Price;
    public DateTime PublishDate;
    public string Description;

    public override string ToString()
    {
        return Author;
    }
}

public class ReadXMLFile : MonoBehaviour
{
    private void Start()
    {
        foreach(var element in ReadXML())
        {
            Debug.Log(element.Title);
        }
    }

    public List<Book> ReadXML()
    {
        List<Book> result = new List<Book>();

        TextAsset txtAsset = Resources.Load<TextAsset>("sample");
        var doc = XDocument.Parse(txtAsset.text);

        var Books = doc.Element("catalog").Elements("book");
        foreach(var book in Books)
        {
            Book temp = new Book();
            if (book.Attribute("id") != null)
            {
                temp.ID = book.Attribute("id").Value;
                temp.Author = book.Element("author").Value;
                temp.Title = book.Element("title").Value;
                temp.Genre = book.Element("genre").Value;
                temp.Price = decimal.Parse(book.Element("price").Value);
                temp.PublishDate = DateTime.Parse(book.Element("publish_date").Value);
                temp.Description = book.Element("description").Value;
            }

            if(temp.ID != null)
                result.Add(temp);
        }


        return result;
    }
}
