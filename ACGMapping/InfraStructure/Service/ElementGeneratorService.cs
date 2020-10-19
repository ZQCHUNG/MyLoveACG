using System;
using System.Collections.Generic;
using ACGMapping.InfraStructure.ENum;
using ACGMapping.InfraStructure.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ACGMapping.InfraStructure.Service
{
    public class ElementGeneratorService
    {
        public IEnumerable<SelectListItem> TableToDropdownList<T>(IEnumerable<T> tables, int filter, Func<T, string> text, Func<T, int> value, bool allSelection)
        {
            var items = new List<SelectListItem>();

            if (allSelection)
            {
                items = DefaultSelectListItem();
            }

            foreach (var o in tables)
            {
                var item = new SelectListItem()
                {
                    Text = text(o),
                    Value = value(o).ToString(),
                    Selected = filter == value(o)
                };

                items.Add(item);
            }

            return items;
        }

        public IEnumerable<SelectListItem> TableToDropdownList<T>(IEnumerable<T> tables, int filter, Func<T, string> text, Func<T, int> value)
        {
            return TableToDropdownList(tables, filter, text, value, false);
        }

        public IEnumerable<SelectListItem> ENumToDropDownList<T>(string filter)
        {
            var items = new List<SelectListItem>();

            foreach (T enumType in Enum.GetValues(typeof(T)))
            {
                var item = new SelectListItem()
                {
                    Value = (Convert.ToInt32(enumType)).ToString(),
                    Text = enumType.ToString(),
                    Selected = filter == Convert.ToInt32(enumType).ToString()
                };

                items.Add(item);
            }

            return items;
        }
        public  IEnumerable<SelectListItem> ENumToDropDownList<T>(string filter, bool generateNotAssigned)
        {
            var items = new List<SelectListItem>();

            if (generateNotAssigned)
            {
                items = DefaultSelectListItem();
            }

            foreach (T enumType in Enum.GetValues(typeof(T)))
            {
                var item = new SelectListItem()
                {
                    Value = (Convert.ToInt32(enumType)).ToString(),
                    Text = enumType.ToString(),
                    Selected = filter == enumType.ToString()
                };

                items.Add(item);
            }

            return items;
        }

        public  List<SelectListItem> CreateListItems(IEnumerable<string> lists, string filter)
        {
            var items = new List<SelectListItem>();

            foreach (var item in lists)
            {
                items.Add(new SelectListItem()
                {
                    Value = item,
                    Text = item,
                    Selected = filter == item
                });
            }

            return items;
        }

        public List<SelectListItem> DefaultSelectListItem()
        {
            var items = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text = "不指定",
                    Value = EStatus.未選擇.ToDescription()
                }
            };
            return items;
        }
    }
}