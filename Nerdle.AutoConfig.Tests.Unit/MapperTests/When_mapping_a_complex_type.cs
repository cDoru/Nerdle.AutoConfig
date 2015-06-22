﻿using System.Collections.Generic;
using System.Xml.Linq;
using FluentAssertions;
using Nerdle.AutoConfig.Mappers;
using NUnit.Framework;

namespace Nerdle.AutoConfig.Tests.Unit.MapperTests
{
    [TestFixture]
    public class When_mapping_a_complex_type
    {
        readonly IMapper _mapper = new ComplexMapper();

        [Test]
        public void The_instance_is_created()
        {
            var xElement = XElement.Parse("<Foo Bar=\"test\"><Baz>42</Baz></Foo>");
            var result = _mapper.Map(xElement, typeof (IFoo)) as IFoo;
            result.Should().NotBeNull();
        }

        [Test]
        public void The_properties_are_populated()
        {
            var xElement = XElement.Parse("<Foo Bar=\"test\"><Baz>42</Baz></Foo>");
            var result = _mapper.Map(xElement, typeof(IFoo)) as IFoo;
            result.Bar.Should().Be("test");
            result.Baz.Should().Be(42);
        }
    }

    public interface IFoo
    {
        string Bar { get; }
        int Baz { get; }
    }
}
